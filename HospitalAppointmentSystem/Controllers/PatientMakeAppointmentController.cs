using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "patient")]
    public class PatientMakeAppointmentController : Controller
    {
        private readonly IClinicService _clinicManager;

        public PatientMakeAppointmentController(IClinicService clinicManager)
        {
            _clinicManager = clinicManager;
        }

        public IActionResult Index()
        {
            var clinics = _clinicManager.TGetList();
            ViewBag.Clinics = clinics;
            return View();
        }
    }
}
