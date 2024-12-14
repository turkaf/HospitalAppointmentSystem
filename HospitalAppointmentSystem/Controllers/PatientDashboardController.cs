using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    public class PatientDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
