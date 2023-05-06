using System;
using System.Collections.Generic;

namespace HMS.Data.Models
{
    public class schidule
    {
        public int id { get; set; }

        public int NOR { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }

        public List<patient> patients { get; set; }

        public List<patientSchdule> patientSchdules { get; set; }

        public List<nurse> nurses { get; set; }

        public List<nurseSchidule> nurseSchidules { get; set; }

        public List<doctor> doctors { get; set; }

        public List<doctorSchidule> doctorSchidule { get; set; }
    }
}
