using System;
using System.ComponentModel.DataAnnotations;

namespace Winston.Models
{
    public class OfferViewModel
    {

        public long OfferID { get; set; }
        public string Title { get; set; }

        [Display(Name = "Date From")]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }

        [Display(Name = "Date To")]
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }

        [Display(Name = "User Segment")]
        public long UserSegment { get; set; }

        [Display(Name = "User Segment")]
        public String UserSegmentName { get; set; }

        public string Messages { get; set; }
        public bool Active { get; set; }
    }
}
