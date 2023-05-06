namespace HMS.Data.Models
{
    public class doctorSchidule
    {
        public int doctortId { get; set; }
        public doctor doctor { get; set; }
        public int schiduleId { get; set; }
        public schidule Schidule { get; set; }
    }
}
