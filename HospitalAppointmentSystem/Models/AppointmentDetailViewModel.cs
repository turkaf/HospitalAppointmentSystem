using EntityLayer.Concrete;
using EntityLayer.Enums;

namespace HospitalAppointmentSystem.Models
{
    public class AppointmentDetailViewModel
    {
        public int AppointmentID { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public int PatientAge { get; set; }
        public GenderEnum Gender { get; set; }
        public string PatientEmail { get; set; }
        public string PatientPhone { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string ClinicName { get; set; }
        public bool? Status { get; set; }
        public List<PatientAnswers> PatientAnswersList { get; set; }
    }
}
