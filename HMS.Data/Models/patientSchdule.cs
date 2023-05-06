namespace HMS.Data.Models
{
    public class patientSchdule
    {
        public int patientId { get; set; }
        public patient patient { get; set; }
        public int schiduleId { get; set; }
        public schidule Schidule { get; set; }
    }
}
