using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminCheckupsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
