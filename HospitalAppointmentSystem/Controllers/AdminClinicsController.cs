using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminClinicsController : Controller
    {
        private readonly ClinicManager _clinicManager;

        public AdminClinicsController()
        {
            _clinicManager = new ClinicManager(new EfClinicDal());
        }

        public IActionResult Index()
        {
            var values = _clinicManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddClinic()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddClinic(Clinic clinic, IFormFile Photo)
        {
            if (Photo == null || Photo.Length == 0)
            {
                ModelState.AddModelError("Photo", "Photo is required.");
                return View(clinic);
            }

            var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "UIFrontend", "images", "Clinics");
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

            clinic.Photo = "/UIFrontend/images/Clinics/" + uniqueFileName;

            _clinicManager.TAdd(clinic);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteClinic(int ClinicID)
        {
            var clinic = _clinicManager.TGetByID(ClinicID);

            if (clinic != null)
            {
                var photoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", clinic.Photo.TrimStart('/'));
                if (System.IO.File.Exists(photoPath))
                {
                    System.IO.File.Delete(photoPath);
                }

                _clinicManager.TDelete(clinic);
            }

            return RedirectToAction("Index");
        }
    }
}
