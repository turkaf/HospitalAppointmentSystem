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

        //[HttpPost]
        //public IActionResult CreateAppointment(AppointmentViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var clinics = _clinicManager.TGetList();
        //        ViewBag.Clinics = clinics;

        //        var availableCheckups = _checkupService.TGetList();
        //        var patient = _patientService.TGetByID(model.PatientID);

        //        var patientAge = CalculateAge(patient.DateOfBirth);

        //        var filteredCheckups = availableCheckups.Where(checkup =>
        //            checkup.MinAge <= patientAge &&
        //            checkup.MaxAge >= patientAge &&
        //            checkup.Gender == patient.Gender).ToList();

        //        var viewModel = new PatientCheckupViewModel
        //        {
        //            AvailableCheckups = filteredCheckups
        //        };

        //        return View("Index", viewModel);
        //    }

        //    var patientId = model.PatientID;
        //    var appointment = new Appointment
        //    {
        //        PatientID = patientId,
        //        DoctorID = model.DoctorID,
        //        AppointmentDate = model.AppointmentDate,
        //        AppointmentTime = model.AppointmentTime,
        //        Status = true
        //    };

        //    _appointmentService.TAdd(appointment);

        //    foreach (var checkupAnswer in model.PatientAnswers)
        //    {
        //        var patientAnswer = new PatientAnswers
        //        {
        //            AppointmentID = appointment.AppointmentID,
        //            CheckupID = checkupAnswer.CheckupID,
        //            Answer = checkupAnswer.Answer,
        //            PdfFile = checkupAnswer.PdfFile
        //        };

        //        _patientAnswersService.TAdd(patientAnswer);
        //    }

        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult CreateAppointment(int PatientID, int DoctorID, DateTime AppointmentDate, TimeSpan AppointmentTime, int[] checkupIds, bool[] answers, IFormFile[] pdfFiles)
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
                DoctorID = doctorId,
                AppointmentDate = appointmentDate,
                AppointmentTime = appointmentTime,
                Status = true
            };

            _appointmentService.TAdd(appointment);

            for (int i = 0; i < checkupIds.Length; i++)
            {
                var patientAnswer = new PatientAnswers
                {
                    AppointmentID = appointment.AppointmentID,
                    CheckupID = checkupIds[i],
                    Answer = answers[i],
                    PdfFile = pdfFiles[i]?.FileName
                };

                if (pdfFiles[i] != null)
                {
                    var filePath = Path.Combine("uploads", pdfFiles[i].FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        pdfFiles[i].CopyTo(stream);
                    }

                    patientAnswer.PdfFile = filePath;
                }

                _patientAnswersService.TAdd(patientAnswer);
            }

            return RedirectToAction("Index");
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
