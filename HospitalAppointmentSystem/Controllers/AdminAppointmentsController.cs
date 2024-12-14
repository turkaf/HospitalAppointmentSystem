using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    public class AdminAppointmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
