namespace HMS.Data.Models
{
    public class PatientTreatment
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
    }
}
