using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "patient")]
    public class PatientPrescriptionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
