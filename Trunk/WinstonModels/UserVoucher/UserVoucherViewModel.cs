using System;
using System.ComponentModel.DataAnnotations;

namespace Winston.Models
{
    public class UserVoucherViewModel
    {
        public long UserVoucherID { get; set; }
        [Display(Name = "Voucher Code")]
        public string Code { get; set; }
        public long OfferID { get; set; }
        [Display(Name = "Offer")]
        public string OfferTitle { get; set; }
        public long VoucherID { get; set; }
        public long UserID { get; set; }
        [Display(Name = "Valid From")]
        public DateTime ValidFrom { get; set; }
        [Display(Name = "Valid To")]
        public DateTime ValidTo { get; set; }
        [Display(Name = "Reedeem Date")]
        public DateTime RedeemDate { get; set; }
        public bool Valid { get; set; }
        public int PointCost { get; set; }
    }
}
