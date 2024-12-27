﻿using BusinessLayer.Abstract;
using HospitalAppointmentSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "patient")]
    public class PatientAppointmentsController : Controller
    {
        IAppointmentService _appointmentService;

        public PatientAppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            var patientId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "PatientID")?.Value);

            var appointments = _appointmentService.TGetListAppointmentWithPatient()
                .Where(a => a.PatientID == patientId)
                .Select(a => new AppointmentListViewModel
                {
                    AppointmentID = a.AppointmentID,
                    PatientFirstName = a.Patient.FirstName,
                    PatientLastName = a.Patient.LastName,
                    DoctorFirstName = a.Doctor.FirstName,
                    DoctorLastName = a.Doctor.LastName,
                    Clinic = a.Doctor.Clinic.Name,
                    AppointmentDate = a.AppointmentDate.ToString("dd.MM.yyyy"),
                    AppointmentTime = a.AppointmentTime.ToString(@"hh\:mm"),
                    Status = a.Status
                })
                .ToList();

            return View(appointments);
        }

        [HttpPost]
        public IActionResult CancelAppointment(int appointmentId)
        {
            var appointment = _appointmentService.TGetByID(appointmentId);
            if (appointment != null)
            {
                appointment.Status = false;
                _appointmentService.TUpdate(appointment);
            }

            return RedirectToAction("Index");
        }

        public IActionResult ViewDetails(int appointmentId)
        {
            var appointment = _appointmentService.TGetListAppointmentWithPatient()
                .FirstOrDefault(a => a.AppointmentID == appointmentId);

            if (appointment == null)
            {
                return NotFound();
            }

            var appointmentDetails = new PatientAppointmentDetailViewModel
            {
                //AppointmentID = appointment.AppointmentID,
                PatientFirstName = appointment.Patient.FirstName,
                PatientLastName = appointment.Patient.LastName,
                PatientAge = DateTime.Now.Year - appointment.Patient.DateOfBirth.Year,
                PatientGender = appointment.Patient.Gender,
                PatientEmail = appointment.Patient.Email,
                PatientPhone = appointment.Patient.Phone,
                AppointmentDate = appointment.AppointmentDate.ToString("dd.MM.yyyy"),
                AppointmentTime = appointment.AppointmentTime.ToString(@"hh\:mm"),
                Clinic = appointment.Doctor.Clinic.Name,
                DoctorFirstName = appointment.Doctor.FirstName,
                DoctorLastName = appointment.Doctor.LastName,
                Status = appointment.Status
            };

            return View(appointmentDetails);
        }

    }
}
