using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Doctor
    {
        [Key]
        public int DoctorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ClinicID { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Navigation Properties
        public virtual Clinic Clinic { get; set; }
        public virtual List<Appointment> Appointments { get; set; }
    }
}
