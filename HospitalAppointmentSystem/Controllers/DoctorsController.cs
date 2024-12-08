using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    public class DoctorsController : Controller
    {
        DoctorManager doctorManager = new DoctorManager(new EfDoctorDal());
        public IActionResult Index()
        {
            var values = doctorManager.TGetList();

            return View(values);
        }
    }
}
