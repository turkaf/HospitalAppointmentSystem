using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    public class DoctorDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
