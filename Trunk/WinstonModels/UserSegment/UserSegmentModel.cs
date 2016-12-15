using System;
using Winston.Common;

namespace Winston.Models
{
    public class UserSegmentModel
    {
        public long UserSegmentID { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime? DateOfBirthFrom { get; set; }
        public DateTime? DateofBirthTo { get; set; }
        public string ZipCode { get; set; }
    }
}
