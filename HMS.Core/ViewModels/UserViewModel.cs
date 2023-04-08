using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DOB { get; set; }
        public string ImageUrl { get; set; }
        public string UserType { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
