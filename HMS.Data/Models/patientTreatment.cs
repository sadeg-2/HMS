namespace HMS.Data.Models
{
    public class patientTreatment
    {
        public int patientId { get; set; }
        public patient patient { get; set; }
        public int treatmentId { get; set; }
        public treatment Treatment { get; set; }
    }
}
