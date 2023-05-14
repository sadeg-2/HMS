using HMS.Core.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Data.Models
{
    public class Doctor : BaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Nurse> Nurses { get; set; }

        public int NumberOfNurses { get; set; }

        public ShiftsOfEmployees shiftsOfDoctor { get; set; }

        //public List<schidule> schidules { get; set; }
        //public List<doctorSchidule> doctorSchidules { get; set; }
    }
}
