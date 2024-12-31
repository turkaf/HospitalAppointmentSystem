using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "patient")]
    public class PatientDashboardController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPrescriptionService _prescriptionService;

        public PatientDashboardController(IAppointmentService appointmentService, IPrescriptionService prescriptionService)
        {
            _appointmentService = appointmentService;
            _prescriptionService = prescriptionService;
        }

        public async Task<IActionResult> Index()
        {
            var patientId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "PatientID").Value);

            var appointments = await Task.Run(() => _appointmentService.GetAppointmentsByPatientId(patientId));
            var totalAppointments = appointments.Count();

            // Buraya yazılacak
            var prescriptions = await Task.Run(() => _prescriptionService.TGetListPrescriptionWithAppointment().Where(p => p.Appointment.PatientID == patientId).ToList());
            var totalPrescriptions = prescriptions.Count();

            ViewBag.TotalAppointments = totalAppointments;
            ViewBag.TotalPrescriptions = totalPrescriptions;

            return View();
        }
    }
}
