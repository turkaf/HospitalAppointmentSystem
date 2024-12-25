using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminDashboardController : Controller
    {
        DoctorManager doctorManager = new DoctorManager(new EfDoctorDal());
        PatientManager patientManager = new PatientManager(new EfPatientDal());
        
        public IActionResult Index()
        {
            var totalDoctors = doctorManager.TGetList().Count();
            var totalPatients = patientManager.TGetList().Count();

            ViewData["TotalDoctors"] = totalDoctors;
            ViewData["TotalPatients"] = totalPatients;

            return View();
        }
    }
}
