using System.Collections.Generic;

namespace HMS.Data.Models
{
    public class patient
    {
        public int Id { get; set; }

        public nurse nurses { get; set; }

        public string userId { get; set; }
        public User user { get; set; }

        public List<treatment> treatments { get; set; }

        public List<schidule> schidules { get; set; }

        public List<patientSchdule> patientSchdules { get; set; }

        public List<patientTreatment> patientTreatment { get; set; }

    }
}
