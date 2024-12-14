using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    public class DoctorPrescribeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
