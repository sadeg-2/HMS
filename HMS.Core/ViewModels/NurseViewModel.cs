using HMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.ViewModels
{
    public class NurseViewModel
    {
        public int id { get; set; }

        public UserViewModel User { get; set; }

        public string ShiftsOfNurse { get; set; }
        public int NumberOfPatients { get; set; }
        public string HasDoctor { get; set; }

        public DoctorViewModel doctor { get; set; }

    } 
}
