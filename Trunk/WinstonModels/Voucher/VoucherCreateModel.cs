using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Winston.Common;

namespace Winston.Models
{
    public class VoucherCreateModel
    {
        public long VoucherID { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Images { get; set; }

        [Required]
        [Display(Name = "Point Cost")]
        public int PointCost { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The Voucher Type field is required")]
        [EnumDataType(typeof(VoucherType))]
        [Display(Name = "Voucher Type")]
        public VoucherType Type { get; set; }

        [Required]
        public int Amount { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "The Calculation Type field is required")]
        [EnumDataType(typeof(CalculationType))]
        [Display(Name = "Calculation Type")]
        public CalculationType CalculationType { get; set; }

        [Required]
        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Key Account")]
        public long? KeyAcountID { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Item> KeyAccounts { get; set; }

        [Required]
        [Display(Name = "Offer")]
        public long OfferID { get; set; }
        public List<Item> Offers { get; set; }

    }
}
