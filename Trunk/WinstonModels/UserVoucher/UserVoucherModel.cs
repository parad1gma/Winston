using System;

namespace Winston.Models
{
    public class UserVoucherModel
    {
        public long UserVoucherID { get; set; }
        public string Code { get; set; }
        public long OfferID { get; set; }
        public long VoucherID { get; set; }
        public long UserID { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime RedeemDate { get; set; }
        public bool Valid { get; set; }

    }
}
