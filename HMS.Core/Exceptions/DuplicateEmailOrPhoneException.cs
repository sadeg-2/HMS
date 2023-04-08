using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Exceptions
{
    public class DuplicateEmailOrPhoneException: Exception
    {
        public DuplicateEmailOrPhoneException() : base(" Email or phone is Duplicated") { 
        }
    }
}
