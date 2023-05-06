using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Data.Models
{
    public class doctor
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public User user { get; set; }
        public List<nurse> nurses { get; set; }
        public List<schidule> schidules { get; set; }
        public List<doctorSchidule> doctorSchidules { get; set; }
    }
}
