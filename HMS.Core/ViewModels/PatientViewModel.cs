using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.ViewModels
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public UserViewModel User { get; set; }

        public string? NameOfNurse { get; set; }

        public string? NameOfDoctor { get; set; }


    }
}
