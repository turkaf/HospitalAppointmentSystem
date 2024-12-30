using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public bool? Status { get; set; }
        // Navigation Properties
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual List<Prescription> Prescriptions { get; set; }
        public virtual List<PatientAnswers> PatientAnswers { get; set; }
    }
}
