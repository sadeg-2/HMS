﻿using HMS.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Data.Models
{
    public class User : IdentityUser
    {
        
        [Required]
        public string FullName { get; set; }
        public DateTime? DOB { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsDelete { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public UserType UserType { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public Nurse Nurse { get; set; }
        
        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }

        public User() {
            CreatedBy = "Me";
            UpdatedBy = "Me";
        }
    }
}
