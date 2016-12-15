using System;
using System.ComponentModel.DataAnnotations;
using Winston.Common;

namespace Winston.Models
{
    public class UserViewModel
    {
        public long UserID { get; set; }
        [Display(Name = "UserName")]
        public string Username { get; set; }

        public string Password { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        public string City { get; set; }
        public string Street { get; set; }
        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }
        [Display(Name = "Adress Info")]
        public string AdressInfo { get; set; }
        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Point Balance")]
        public int PointBalance { get; set; }

        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }



    }
}
