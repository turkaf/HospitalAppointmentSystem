using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using EntityLayer.Enums;

namespace HospitalAppointmentSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public LoginController(IAdminService adminService, IDoctorService doctorService, IPatientService patientService)
        {
            _adminService = adminService;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string FirstName, string LastName, string IdentityNumber, DateTime DateOfBirth, GenderEnum Gender, string Phone, string Email, string Password)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var newPatient = new Patient
            {
                FirstName = FirstName,
                LastName = LastName,
                IdentityNumber = IdentityNumber,
                DateOfBirth = DateOfBirth,
                Gender = Gender,
                Phone = Phone,
                Email = Email,
                Password = Password
            };

            _patientService.TAdd(newPatient);

            return RedirectToAction("SignIn");
        }


        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult SignIn(string email, string password, string role)
        //{
        //    if (role == "admin")
        //    {
        //        var admin = _adminService.ValidateAdmin(email, password);
        //        if (admin != null)
        //        {
        //            HttpContext.Session.SetString("Role", "admin");
        //            return RedirectToAction("Index", "AdminDashboard");
        //        }
        //    }
        //    else if (role == "doctor")
        //    {
        //        var doctor = _doctorService.ValidateDoctor(email, password);
        //        if (doctor != null)
        //        {
        //            HttpContext.Session.SetString("Role", "doctor");
        //            return RedirectToAction("Index", "DoctorDashboard");
        //        }
        //    }
        //    else if (role == "patient")
        //    {
        //        var patient = _patientService.ValidatePatient(email, password);
        //        if (patient != null)
        //        {
        //            HttpContext.Session.SetString("Role", "patient");
        //            return RedirectToAction("Index", "PatientDashboard");
        //        }
        //    }

        //    ModelState.AddModelError("", "Invalid credentials or role.");
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> SignIn(string email, string password, string role)
        {
            if (role == "admin")
            {
                var admin = _adminService.ValidateAdmin(email, password);
                if (admin != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, admin.UserName),
                        new Claim(ClaimTypes.Role, "admin")
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "AdminDashboard");
                }
            }
            else if (role == "doctor")
            {
                var doctor = _doctorService.ValidateDoctor(email, password);
                if (doctor != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, doctor.Email),
                        new Claim(ClaimTypes.Role, "doctor"),
                        new Claim("DoctorID", doctor.DoctorID.ToString())
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "DoctorDashboard");
                }
            }
            else if (role == "patient")
            {
                var patient = _patientService.ValidatePatient(email, password);
                if (patient != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, patient.Email),
                        new Claim(ClaimTypes.Role, "patient")
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Index", "PatientDashboard");
                }
            }

            ModelState.AddModelError("", "Invalid credentials or role.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();

            return RedirectToAction("SignIn", "Login");
        }
    }
}
