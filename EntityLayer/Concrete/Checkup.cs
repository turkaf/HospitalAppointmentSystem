using EntityLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Checkup
    {
        [Key]
        public int CheckupID { get; set; }
        public string Question { get; set;}
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public GenderEnum Gender { get; set; }
        // Navigational Property
        public virtual List<PatientAnswers> PatientAnswers { get; set; }
    }
}
