using EntityLayer.Concrete;
using EntityLayer.Enums;

namespace HospitalAppointmentSystem.Models
{
    public class PatientAppointmentDetailViewModel
    {
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public int PatientAge { get; set; }
        public GenderEnum PatientGender { get; set; }
        public string PatientEmail { get; set; }
        public string PatientPhone { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public string Clinic { get; set; }
        public string DoctorFirstName { get; set; }
        public string DoctorLastName { get; set; }
        public bool? Status { get; set; }

        public List<PatientAnswers> PatientAnswersList { get; set; }
    }
}
