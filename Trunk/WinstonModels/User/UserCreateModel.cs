using System;
using System.ComponentModel.DataAnnotations;
using Winston.Common;

namespace Winston.Models
{
    public class UserCreateModel
    {
        public long UserID { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Street number")]
        public string StreetNumber { get; set; }

        [Display(Name = "Adress info")]
        public string AdressInfo { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        public int PointBalance { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
