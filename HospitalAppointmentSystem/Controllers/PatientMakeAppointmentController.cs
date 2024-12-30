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

        public PatientMakeAppointmentController(IClinicService clinicManager, ICheckupService checkupService, IPatientService patientService, IDoctorService doctorService)
        {
            _clinicManager = clinicManager;
            _checkupService = checkupService;
            _patientService = patientService;
            _doctorService = doctorService;
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

        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
