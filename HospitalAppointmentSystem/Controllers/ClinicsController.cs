using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    public class ClinicsController : Controller
    {
        ClinicManager clinicManager = new ClinicManager(new EfClinicDal());
        public IActionResult Index()
        {
            var values = clinicManager.TGetList();
            return View(values);
        }
    }
}
