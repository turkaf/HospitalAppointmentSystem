using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "doctor")]
    public class DoctorDashboardController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        
        public DoctorDashboardController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<IActionResult> Index()
        {
            var doctorId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "DoctorID").Value);

            var appointments = await Task.Run(() => _appointmentService.GetAppointmentsByDoctorId(doctorId));

            var totalPatients = appointments.Select(a => a.PatientID).Distinct().Count();
            var totalAppointments = appointments.Count();

            ViewBag.TotalPatients = totalPatients;
            ViewBag.TotalAppointments = totalAppointments;

            return View();
        }
    }
}
