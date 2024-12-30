namespace HospitalAppointmentSystem.Models
{
    public class AppointmentViewModel
    {
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }

        public List<PatientAnswerViewModel> PatientAnswers { get; set; }
    }
}
