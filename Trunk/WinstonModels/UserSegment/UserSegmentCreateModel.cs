using System;
using System.ComponentModel.DataAnnotations;
using Winston.Common;

namespace Winston.Models
{
    public class UserSegmentCreateModel
    {
        public long UserSegmentID { get; set; }

        [Required]
        public string Name { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Date of Birth From")]
        public DateTime? DateOfBirthFrom { get; set; }

        [Display(Name = "Date of Birth To")]
        public DateTime? DateOfBirthTo { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
    }
}
