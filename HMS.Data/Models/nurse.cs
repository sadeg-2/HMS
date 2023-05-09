using HMS.Core.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HMS.Data.Models
{
    public class Nurse : BaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public List<Patient>? Patients { get; set; }

        public ShiftsOfEmployees ShiftsOfNurse { get; set; }      
        public int NumberOfPatients { get; set; }
        public bool HasDoctor { get; set; }
        public int DoctorId { get; set; }
        public Doctor? Doctors { get; set; }


        //public List<schidule> schidules { get; set; }
        //public List<nurseSchidule> nurseSchidules { get; set; }
        
    }
}
