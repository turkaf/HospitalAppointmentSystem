using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    public class DoctorPatientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
