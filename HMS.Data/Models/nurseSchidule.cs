namespace HMS.Data.Models
{
    public class nurseSchidule
    {
        public int nurseId { get; set; }
        public nurse nurse { get; set; }
        public int schiduleId { get; set; }
        public schidule Schidule { get; set; }
    }
}
