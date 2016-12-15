using System;
using System.ComponentModel.DataAnnotations;
using Winston.Common;

namespace Winston.Models
{
    public class VoucherViewModel
    {
        [Display(Name = "Voucher ID")]
        public long VoucherID { get; set; }
        public long OfferID { get; set; }
        public string Code { get; set; }
        [Display(Name = "Voucher")]
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Images { get; set; }
        [Display(Name = "Point Cost")]
        public int PointCost { get; set; }
        public VoucherType Type { get; set; }
        public int Amount { get; set; }
        public CalculationType CalculationType { get; set; }
        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }
        [Display(Name = "Key Account")]
        public string KeyAccountName { get; set; }
        [Display(Name = "Offer")]
        public string OfferName { get; set; }
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        public bool Assigned { get; set; }

    }
}
