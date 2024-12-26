using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminDashboardController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;

        public AdminDashboardController(IDoctorService doctorService, IPatientService patientService, IAppointmentService appointmentService)
        {
            _doctorService = doctorService;
            _patientService = patientService;
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            var totalDoctors = _doctorService.TGetList().Count();
            var totalPatients = _patientService.TGetList().Count();
            var totalAppointments = _appointmentService.TGetList().Count();

            ViewData["TotalDoctors"] = totalDoctors;
            ViewData["TotalPatients"] = totalPatients;
            ViewData["TotalAppointments"] = totalAppointments;

            return View();
        }
    }
}
