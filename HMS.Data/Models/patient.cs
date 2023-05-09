using System.Collections.Generic;

namespace HMS.Data.Models
{
    public class Patient : BaseEntity
    {
        public int Id { get; set; }

        public bool HasNurse { get; set; }

        public int NurseId { get; set; }
        public Nurse? Nurse { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public List<Treatment>? Treatments { get; set; }

        public List<Schidule>? Schidules { get; set; }

        public List<PatientSchdule>? PatientSchdules { get; set; }

        public List<PatientTreatment>? PatientTreatment { get; set; }

    }
}
