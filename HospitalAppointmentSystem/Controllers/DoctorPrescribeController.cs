using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "doctor")]
    public class DoctorPrescribeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
