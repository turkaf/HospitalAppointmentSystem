using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    public class PatientAppointmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
