using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using HospitalAppointmentSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "patient")]
    public class PatientPrescriptionsController : Controller
    {
        private readonly IPrescriptionService _prescriptionService;

        public PatientPrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        public IActionResult Index()
        {
            var patientId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "PatientID").Value);

            var prescriptions =  _prescriptionService.TGetListPrescriptionWithAppointment()
                .Where(p => p.Appointment.PatientID == patientId)
                .Select(a => new PrescriptionListViewModel
                {
                    ID = a.PrescriptionID,
                    Clinic = a.Appointment.Doctor.Clinic.Name,
                    Doctor = a.Appointment.Doctor.FirstName + " " + a.Appointment.Doctor.LastName,
                    Date = a.Appointment.AppointmentDate.ToString("dd.MM.yyyy"),
                    Time = a.Appointment.AppointmentTime.ToString(@"hh\:mm")
                }).ToList();

            return View(prescriptions);
        }

        public IActionResult ViewDetails(int prescriptionId)
        {
            var prescription = _prescriptionService.TGetListPrescriptionWithAppointment()
                .FirstOrDefault(a => a.PrescriptionID == prescriptionId);

            if (prescription == null)
            {
                return NotFound();
            }

            var prescriptionDetails = new PrescriptionListViewModel
            {
                ID = prescription.AppointmentID,
                Clinic = prescription.Appointment.Doctor.Clinic.Name,
                Doctor = prescription.Appointment.Doctor.FirstName + " " + prescription.Appointment.Doctor.LastName,
                Date = prescription.Appointment.AppointmentDate.ToString("dd.MM.yyyy"),
                Time = prescription.Appointment.AppointmentTime.ToString(@"hh\:mm"),
                Diagnosis = prescription.Diagnosis,
                Medicine1 = prescription.Medicine1,
                Dosage1 = prescription.Dosage1,
                Instruction1 = prescription.Instruction1,
                Medicine2 = prescription.Medicine2,
                Dosage2 = prescription.Dosage2,
                Instruction2 = prescription.Instruction2,
                Medicine3 = prescription.Medicine3,
                Dosage3 = prescription.Dosage3,
                Instruction3 = prescription.Instruction3
            };

            return View(prescriptionDetails);
        }
    }
}
