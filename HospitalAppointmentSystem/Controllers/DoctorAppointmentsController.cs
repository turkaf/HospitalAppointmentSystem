using BusinessLayer.Abstract;
using EntityLayer.Concrete;
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
        IPatientAnswersService _patientAnswersService;
        IPrescriptionService _prescriptionService;

        public DoctorAppointmentsController(IAppointmentService appointmentService, IPatientAnswersService patientAnswersService, IPrescriptionService prescriptionService)
        {
            _appointmentService = appointmentService;
            _patientAnswersService = patientAnswersService;
            _prescriptionService = prescriptionService;
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

            var patientAnswers = _patientAnswersService.TGetListAnswersWithCheckups()
                .Where(pa => pa.AppointmentID == id)
                .ToList();

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
                Status = appointment.Status,

                PatientAnswersList = patientAnswers
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
        public IActionResult Prescribe(int id) 
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
                AppointmentDate = appointment.AppointmentDate.ToString("dd.MM.yyyy")
            };

            return View(appointmentDetailViewModel);
        }

        [HttpPost]
        public IActionResult SavePrescription(int appointmentId, string diagnosis, string? medicine1, string? dosage1, string? instruction1,
            string? medicine2, string? dosage2, string? instruction2, string? medicine3, string? dosage3, string? instruction3)
        {

            var diagnosisvar = diagnosis;

            var appointment = _appointmentService.TGetByID(appointmentId);
            if (appointment == null)
            {
                return NotFound();
            }

            var prescription = _prescriptionService.TGetList()
                .FirstOrDefault(p => p.AppointmentID == appointmentId);

            prescription = new Prescription
            {
                AppointmentID = appointmentId,
                Diagnosis = diagnosis,
                Medicine1 = medicine1,
                Dosage1 = dosage1,
                Instruction1 = instruction1,
                Medicine2 = medicine2,
                Dosage2 = dosage2,
                Instruction2 = instruction2,
                Medicine3 = medicine3,
                Dosage3 = dosage3,
                Instruction3 = instruction3
            };
            _prescriptionService.TAdd(prescription);


            return RedirectToAction("Index");
        }

    }
}
