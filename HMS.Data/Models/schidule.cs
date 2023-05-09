using System;
using System.Collections.Generic;

namespace HMS.Data.Models
{
    public class Schidule
    {
        public int id { get; set; }

        public int NOR { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }

        public List<Patient> Patients { get; set; }

        public List<PatientSchdule> PatientSchdules { get; set; }

        //public List<nurse> nurses { get; set; }

        //public List<nurseSchidule> nurseSchidules { get; set; }

        //public List<doctor> doctors { get; set; }

        //public List<doctorSchidule> doctorSchidule { get; set; }
    }
}
