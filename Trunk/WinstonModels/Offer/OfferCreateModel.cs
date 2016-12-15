using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Winston.Common;

namespace Winston.Models
{
    public class OfferCreateModel
    {
        public long OfferID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Date From")]
        public DateTime DateFrom { get; set; }

        [Required]
        [Display(Name = "Date To")]
        public DateTime DateTo { get; set; }

        [Required]
        [Display(Name = "User Segment")]
        public long UserSegment { get; set; }
        public List<Item> UserSegmentList { get; set; }

        public string Messages { get; set; }
        public bool Active { get; set; }

    }
}
