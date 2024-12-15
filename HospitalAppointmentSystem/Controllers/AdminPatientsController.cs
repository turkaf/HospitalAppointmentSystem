using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAppointmentSystem.Controllers
{
    public class AdminPatientsController : Controller
    {
        private readonly PatientManager _patientManager;

        public AdminPatientsController()
        {
            _patientManager = new PatientManager(new EfPatientDal());
        }

        public IActionResult Index()
        {
            var values = _patientManager.TGetList();
            return View(values);
        }

        [HttpPost]
        public IActionResult DeletePatient(int PatientID)
        {
            var patient = _patientManager.TGetByID(PatientID);

            if (patient != null)
            {
                _patientManager.TDelete(patient);
            }

            return RedirectToAction("Index");
        }
    }
}
