using BusinessLayer.Abstract;
using HospitalAppointmentSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HospitalAppointmentSystem.Controllers
{
    [Authorize(Roles = "doctor")]
    public class DoctorPatientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
