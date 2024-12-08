using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PrescriptionMedicine
    {
        [Key]
        public int PrescriptionMedicineID { get; set; }
        public int PrescriptionID { get; set; }
        public int MedicineID { get; set; }
        //Navigational Property
        public virtual Prescription Prescription { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
