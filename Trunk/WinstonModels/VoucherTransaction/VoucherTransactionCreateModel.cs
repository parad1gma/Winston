using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Winston.Common;

namespace Winston.Models
{
    public class VoucherTransactionCreateModel
    {
        public long KeyAccountID { get; set; }

        [Required]
        [Display(Name = "User Voucher")]
        public long UserVoucherID { get; set; }
        public List<Item> UserVoucherList { get; set; }
    }
}
