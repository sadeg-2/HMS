using HMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.ViewModels
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public UserViewModel user { get; set; }
        public int NumberOfNurses { get; set; }

        public string shiftsOfDoctor { get; set; }
    }
}
