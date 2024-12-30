namespace HospitalAppointmentSystem.Models
{
    public class PatientAnswerViewModel
    {
        public int CheckupID { get; set; }
        public bool Answer { get; set; }
        public string? PdfFile { get; set; }
    }
}
