﻿using HMS.Core.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Core.Dtos
{
    public class UpdateNurseDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "اسم المستخدم")]
        public string FullName { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "البريد الالكتروني ")]
        public string Email { get; set; }
        
        [Required]
        [Phone]
        [Display(Name = "رقم الجوال ")]
        public string PhoneNumber { get; set; }
        
        [Display(Name = "الصورة")]
        public IFormFile Image { get; set; }
        
        [Display(Name = "تاريخ الميلاد")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        [Required]
        [Display(Name = "موعد المناوبة")]

        public ShiftsOfEmployees ShiftsOfNurse { get; set; }

       
        public UserType UserType { get; set; }

        public UpdateNurseDto() {
            UserType = UserType.Nurse;
        }

    }
}
