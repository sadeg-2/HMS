using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.ViewModels
{
    public class JsonResponse
    {
        public int status { get; set; }
        public int close { get; set; }
        public string msg { get; set; }
    }
}
