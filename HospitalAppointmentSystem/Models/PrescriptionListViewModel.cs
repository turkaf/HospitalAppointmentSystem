namespace HospitalAppointmentSystem.Models
{
    public class PrescriptionListViewModel
    {
        public int ID { get; set; }
        public string Clinic { get; set; }
        public string Doctor { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
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
    }
}
