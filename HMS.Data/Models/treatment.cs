using System.Collections.Generic;

namespace HMS.Data.Models
{
    public class treatment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public List<patient> patient { get; set; }
        public List<patientTreatment> patientTreatment { get; set; }
    }
}
