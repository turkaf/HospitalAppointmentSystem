﻿using System;
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
        public string Diagnosis { get; set; }
        public string? Medicine1 { get; set; }
        public string? Medicine2 { get; set; }
        public string? Medicine3 { get; set; }
        public string? Dosage1 { get; set; }
        public string? Dosage2 { get; set; }
        public string? Dosage3 { get; set; }
        public string? Instruction1 { get; set; }
        public string? Instruction2 { get; set; }
        public string? Instruction3 { get; set; }
        //Navigational Property
        public virtual Appointment Appointment { get; set; }
    }
}
