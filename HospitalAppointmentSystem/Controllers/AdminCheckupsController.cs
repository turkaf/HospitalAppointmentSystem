using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    public class AdminCheckupsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
