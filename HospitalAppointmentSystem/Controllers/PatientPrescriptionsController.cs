using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    public class PatientPrescriptionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
