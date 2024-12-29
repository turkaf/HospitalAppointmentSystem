using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminCheckupsController : Controller
    {
        ICheckupService _checkupService;

        public AdminCheckupsController(ICheckupService checkupService)
        {
            _checkupService = checkupService;
        }

        public IActionResult Index()
        {
            var values = _checkupService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCheckup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCheckup(Checkup checkup) 
        {
            _checkupService.TAdd(checkup);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteCheckup(int CheckupID)
        {
            var checkup = _checkupService.TGetByID(CheckupID);

            if (checkup != null)
            {

                _checkupService.TDelete(checkup);
            }

            return RedirectToAction("Index");
        }
    }
}
