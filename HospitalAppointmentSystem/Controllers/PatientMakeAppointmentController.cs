using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    public class PatientMakeAppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
