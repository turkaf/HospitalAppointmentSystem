using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-R127VMJ\\SQLEXPRESS;database=HospitalDB;integrated security=true;TrustServerCertificate=True;");
        }

        // DbSet Properties
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Checkup> Checkups { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientAnswers> PatientAnswers { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

    }
}
