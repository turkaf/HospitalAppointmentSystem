using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class PatientAnswers
    {
        [Key]
        public int PatientAnswersID { get; set; }
        public int PatientID { get; set; }
        public int CheckupID { get; set; }
        public bool Answer { get; set; }
        // Navigation Properties
        public virtual Patient Patient { get; set; }
        public virtual Checkup Checkup { get; set; }
    }
}
