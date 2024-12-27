using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminAppointmentsController : Controller
    {
        private readonly IAppointmentService _appointmentsService;

        public AdminAppointmentsController(IAppointmentService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        public IActionResult Index()
        {
            var values = _appointmentsService.TGetListAppointmentWithPatient();
            return View(values);
        }

        [HttpPost]
        public IActionResult CancelAppointment(int appointmentId)
        {
            var appointment = _appointmentsService.TGetByID(appointmentId);
            if (appointment != null)
            {
                appointment.Status = false;
                _appointmentsService.TUpdate(appointment);
            }

            return RedirectToAction("Index");
        }
    }
}
