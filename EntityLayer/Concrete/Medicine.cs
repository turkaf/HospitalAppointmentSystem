﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Medicine
    {
        [Key]
        public int MedicineID { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Instruction { get; set; }
        // Navigational Property
        public virtual List<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
