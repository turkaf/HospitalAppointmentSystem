using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "patient")]
    public class PatientMakeAppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
