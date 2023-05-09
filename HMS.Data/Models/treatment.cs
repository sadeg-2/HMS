using System.Collections.Generic;

namespace HMS.Data.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public List<Patient> Patient { get; set; }
        public List<PatientTreatment> PatientTreatment { get; set; }
    }
}
