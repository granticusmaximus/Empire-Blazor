﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.AspNetCore.Identity;

namespace Empire.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public string? Address { get; set; }
        public string? Cellnumber { get; set; }

        [Display(Name = "Profile Picture")]
        public byte[]? ProfilePicture { get; set; }

        public Gender Gender { get; set; }
        public string? City { get; set; }
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
        public DateTime RegisterDate { get; set; } = DateTime.Now;
    }

    public enum Gender
    {
        male,
        female
    }
}
