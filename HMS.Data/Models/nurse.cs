using System.Collections.Generic;

namespace HMS.Data.Models
{
    public class nurse
    {
        public int Id { get; set; }

        public string userId { get; set; }
        public User user { get; set; }

        public List<patient> patients { get; set; }
        public List<schidule> schidules { get; set; }
        public List<nurseSchidule> nurseSchidules { get; set; }
        public int doctorId { get; set; }
        public doctor doctors { get; set; }
    }
}
