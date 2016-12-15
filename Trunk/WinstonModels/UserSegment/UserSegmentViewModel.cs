using System;
using System.ComponentModel.DataAnnotations;
using Winston.Common;

namespace Winston.Models
{
    public class UserSegmentViewModel
    {
        public long UserSegmentID { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }

        [Display(Name = "Date of Birth From")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirthFrom { get; set; }

        [Display(Name = "Date of Birth To")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirthTo { get; set; }

        public string ZipCode { get; set; }
        public bool Assigned { get; set; }

    }
}
