using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Prescription
    {
        [Key]
        public int PrescriptionID { get; set; }
        public int AppointmentID { get; set; }
        public DateTime DateTime { get; set; }
        //Navigational Property
        public virtual Appointment Appointment { get; set; }
        public virtual List<PrescriptionMedicine> PrescriptionMedicines { get; set; }

    }
}
