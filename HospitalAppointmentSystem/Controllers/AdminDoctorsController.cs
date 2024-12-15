using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace HospitalAppointmentSystem.Controllers
{
    public class AdminDoctorsController : Controller
    {
        //private readonly DoctorManager _doctorManager;
        private readonly IDoctorService _doctorManager;
        private readonly ClinicManager _clinicManager;

        public AdminDoctorsController()
        {
            _doctorManager = new DoctorManager(new EfDoctorDal());
            _clinicManager = new ClinicManager(new EfClinicDal());
        }

        public IActionResult Index()
        {
            var values = _doctorManager.TGetListDoctorWithClinic();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDoctor()
        {
            var clinics = _clinicManager.TGetList();
            ViewBag.Clinics = clinics;
            return View();
        }

        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor, IFormFile Photo)
        {
            var clinics = _clinicManager.TGetList();
            ViewBag.Clinics = clinics;

            if (int.TryParse(Request.Form["ClinicID"], out int clinicId))
            {
                doctor.ClinicID = clinicId;
            }
            else
            {
                ModelState.AddModelError("ClinicID", "Invalid Clinic selected.");
                return View(doctor);
            }

            if (Photo == null || Photo.Length == 0)
            {
                ModelState.AddModelError("Photo", "Photo is required.");
                return View(doctor);
            }

            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UIFrontend", "images", "doctors");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(Photo.FileName);
            var filePath = Path.Combine(directoryPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                Photo.CopyTo(stream);
            }

            doctor.Photo = "/UIFrontend/images/doctors/" + uniqueFileName;

            _doctorManager.TAdd(doctor);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteDoctor(int DoctorID)
        {
            var doctor = _doctorManager.TGetByID(DoctorID);

            if (doctor != null)
            {
                var photoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", doctor.Photo.TrimStart('/'));
                if (System.IO.File.Exists(photoPath))
                {
                    System.IO.File.Delete(photoPath);
                }

                _doctorManager.TDelete(doctor);
            }

            return RedirectToAction("Index");
        }

    }
}
