using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Enums;

namespace EntityLayer.Concrete
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // Navigational Property
        public virtual List<Appointment> Appointments { get; set; }
    }
}
