namespace HospitalAppointmentSystem.Models
{
    public class AppointmentListViewModel
    {
        public int AppointmentID { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string? DoctorFirstName { get; set; }
        public string? DoctorLastName { get; set; }
        public string? Clinic { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentTime { get; set; }
        public bool? Status { get; set; }
    }
}
