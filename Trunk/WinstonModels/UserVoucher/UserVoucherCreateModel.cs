using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Winston.Common;

namespace Winston.Models
{
    public class UserVoucherCreateModel
    {
        public long UserVoucherID { get; set; }

        [Required]
        [Display(Name = "Offer")]
        public long OfferID { get; set; }

        [Required]
        [Display(Name = "Voucher")]
        public long VoucherID { get; set; }

        public long UserID { get; set; }
        public DateTime RedeemDate { get; set; }
        public bool Valid { get; set; }

        public List<Item> OfferList { get; set; }
        public List<Item> VoucherList { get; set; }

    }
}
