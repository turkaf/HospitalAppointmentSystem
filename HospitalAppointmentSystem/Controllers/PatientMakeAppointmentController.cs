using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using HospitalAppointmentSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "patient")]
    public class PatientMakeAppointmentController : Controller
    {
        private readonly IClinicService _clinicManager;
        private readonly ICheckupService _checkupService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientAnswersService _patientAnswersService;

        public PatientMakeAppointmentController(IClinicService clinicManager, ICheckupService checkupService, IPatientService patientService, IDoctorService doctorService, IAppointmentService appointmentService, IPatientAnswersService patientAnswersService)
        {
            _clinicManager = clinicManager;
            _checkupService = checkupService;
            _patientService = patientService;
            _doctorService = doctorService;
            _appointmentService = appointmentService;
            _patientAnswersService = patientAnswersService;
        }

        public IActionResult Index()
        {
            var patientId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "PatientID")?.Value);

            var clinics = _clinicManager.TGetList();
            ViewBag.Clinics = clinics;

            var availableCheckups = _checkupService.TGetList();

            var patient = _patientService.TGetByID(patientId);
            if (patient == null)
            {
                return NotFound();
            }

            var patientAge = CalculateAge(patient.DateOfBirth);

            var filteredCheckups = availableCheckups.Where(checkup =>
                checkup.MinAge <= patientAge &&
                checkup.MaxAge >= patientAge &&
                checkup.Gender == patient.Gender).ToList();

            var viewModel = new PatientCheckupViewModel
            {
                AvailableCheckups = filteredCheckups
            };

            ViewBag.PatientName = patient.FirstName + " " + patient.LastName;
            ViewBag.PatientID = patient.PatientID;

            return View(viewModel);
        }

        [HttpGet]
        public JsonResult GetDoctorsByClinic(int clinicId)
        {
            var filteredDoctors = _doctorService.TGetListDoctorWithClinic()
                                                .Where(doctor => doctor.Clinic.ClinicID == clinicId)
                                                .Select(doctor => new
                                                {
                                                    ID = doctor.DoctorID,
                                                    Name = doctor.FirstName + " " + doctor.LastName
                                                })
                                                .ToList();

            return Json(filteredDoctors);
        }

        [HttpPost]
        public IActionResult CreateAppointment(int PatientID, int DoctorID, DateTime AppointmentDate, TimeSpan AppointmentTime,
            Dictionary<int, string> checkupIds, Dictionary<int, bool> answers, IFormFile[] pdfFiles)
        {
            if (!ModelState.IsValid)
            {
                var clinics = _clinicManager.TGetList();
                ViewBag.Clinics = clinics;

                var availableCheckups = _checkupService.TGetList();
                var patient = _patientService.TGetByID(PatientID);

                var patientAge = CalculateAge(patient.DateOfBirth);

                var filteredCheckups = availableCheckups.Where(checkup =>
                    checkup.MinAge <= patientAge &&
                    checkup.MaxAge >= patientAge &&
                    checkup.Gender == patient.Gender).ToList();

                ViewBag.AvailableCheckups = filteredCheckups;
                return View("Index");
            }

            var appointment = new Appointment
            {
                PatientID = PatientID,
                DoctorID = DoctorID,
                AppointmentDate = AppointmentDate,
                AppointmentTime = AppointmentTime
            };

            _appointmentService.TAdd(appointment);

            for (int i = 0; i < checkupIds.Count; i++)
            {
                var checkupId = checkupIds.Keys.ElementAt(i);
                var answer = answers[checkupId];

                var pdffile = pdfFiles;

                var patientAnswer = new PatientAnswers
                {
                    AppointmentID = appointment.AppointmentID,
                    CheckupID = checkupId,
                    Answer = answer,
                    PdfFile = pdfFiles.Length > i ? pdfFiles[i]?.FileName : null
                };

                if (patientAnswer.PdfFile != null)
                {
                    var filePath = Path.Combine("uploads", "uploadpdf", patientAnswer.PdfFile);
                    Directory.CreateDirectory(Path.Combine("wwwroot", "uploads", "uploadpdf"));
                    using (var stream = new FileStream(Path.Combine("wwwroot", filePath), FileMode.Create))
                    {
                        pdfFiles[i].CopyTo(stream);
                    }
                    patientAnswer.PdfFile = filePath;
                }

                _patientAnswersService.TAdd(patientAnswer);
            }

            return RedirectToAction("Index", "PatientAppointments");
        }

        [HttpGet]
        public JsonResult GetBookedTimes(int doctorId, string appointmentDate)
        {
            var date = DateTime.Parse(appointmentDate);

            var bookedAppointments = _appointmentService.TGetList()
                .Where(a => a.DoctorID == doctorId && a.AppointmentDate.Date == date.Date)
                .Select(a => a.AppointmentTime.ToString(@"hh\:mm"))
                .ToList();

            return Json(bookedAppointments);
        }

        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
