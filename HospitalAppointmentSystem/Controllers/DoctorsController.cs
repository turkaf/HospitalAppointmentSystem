using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorService _doctorManager;

        public DoctorsController(IDoctorService doctorManager)
        {
            _doctorManager = doctorManager;
        }

        public IActionResult Index()
        {
            var values = _doctorManager.TGetListDoctorWithClinic();

            return View(values);
        }
    }
}
