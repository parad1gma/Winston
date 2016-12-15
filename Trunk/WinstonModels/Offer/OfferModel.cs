using System;

namespace Winston.Models
{
    public class OfferModel
    {
        public long OfferID { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string UserSegment { get; set; }
        public string Messages { get; set; }
        public bool Active { get; set; }
    }
}
