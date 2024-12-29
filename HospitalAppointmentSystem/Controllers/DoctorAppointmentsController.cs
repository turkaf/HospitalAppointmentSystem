using BusinessLayer.Abstract;
using HospitalAppointmentSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "doctor")]
    public class DoctorAppointmentsController : Controller
    {
        IAppointmentService _appointmentService;

        public DoctorAppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            var doctorId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "DoctorID")?.Value);

            var appointments = _appointmentService.TGetListAppointmentWithPatient()
                .Where(a => a.DoctorID == doctorId)
                .Select(a => new AppointmentListViewModel
                {
                    AppointmentID = a.AppointmentID,
                    PatientFirstName = a.Patient.FirstName,
                    PatientLastName = a.Patient.LastName,
                    AppointmentDate = a.AppointmentDate.ToString("dd.MM.yyyy"),
                    AppointmentTime = a.AppointmentTime.ToString(@"hh\:mm"),
                    Status = a.Status
                })
                .ToList();

            return View(appointments);
        }

        [HttpGet]
        public IActionResult AppointmentDetail(int id)
        {
            var appointment = _appointmentService.TGetListAppointmentWithPatient()
                .FirstOrDefault(a => a.AppointmentID == id);

            if (appointment == null)
            {
                return NotFound();
            }

            var appointmentDetailViewModel = new AppointmentDetailViewModel
            {
                AppointmentID = appointment.AppointmentID,
                PatientFirstName = appointment.Patient.FirstName,
                PatientLastName = appointment.Patient.LastName,
                PatientAge = DateTime.Now.Year - appointment.Patient.DateOfBirth.Year,
                Gender = appointment.Patient.Gender,
                PatientEmail = appointment.Patient.Email,
                PatientPhone = appointment.Patient.Phone,
                AppointmentDate = appointment.AppointmentDate.ToString("dd.MM.yyyy"),
                AppointmentTime = appointment.AppointmentTime.ToString(@"hh\:mm"),
                ClinicName = appointment.Doctor.Clinic.Name,
                Status = appointment.Status
            };

            return View(appointmentDetailViewModel);
        }

        [HttpPost]
        public IActionResult MarkAsCompleted(int appointmentId)
        {
            var appointment = _appointmentService.TGetByID(appointmentId);
            if (appointment != null)
            {
                appointment.Status = true;
                _appointmentService.TUpdate(appointment);
            }

            return RedirectToAction("AppointmentDetail", new { id = appointmentId });
        }


        [HttpGet]
        public IActionResult Prescribe() 
        {
            return View();
        }
    }
}
