using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "patient")]
    public class PatientDashboardController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public PatientDashboardController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public async Task<IActionResult> Index()
        {
            var patientId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "PatientID").Value);

            var appointments = await Task.Run(() => _appointmentService.GetAppointmentsByPatientId(patientId));

            var totalAppointments = appointments.Count();

            ViewBag.TotalAppointments = totalAppointments;

            return View();
        }
    }
}
