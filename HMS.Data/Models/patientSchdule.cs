namespace HMS.Data.Models
{
    public class PatientSchdule
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int SchiduleId { get; set; }
        public Schidule Schidule { get; set; }
    }
}
