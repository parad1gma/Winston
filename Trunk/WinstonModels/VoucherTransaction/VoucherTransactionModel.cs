using System;

namespace Winston.Models
{
    public class VoucherTransactionModel
    {
        public long VoucherTransactionID { get; set; }
        public long UserVoucherID { get; set; }
        public long VoucherID { get; set; }
        public long UserID { get; set; }
        public long OfferID { get; set; }
        public long KeyAccountID { get; set; }
        public int Amount { get; set; }
        public DateTime TimeStamp { get; set; }


    }
}
