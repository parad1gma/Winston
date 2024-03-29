//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Winston.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class VoucherTransaction
    {
        public long VoucherTransactionID { get; set; }
        public long UserVoucherID { get; set; }
        public long VoucherID { get; set; }
        public long UserID { get; set; }
        public long OfferID { get; set; }
        public long KeyAccountID { get; set; }
        public int Amount { get; set; }
        public System.DateTime TimeStamp { get; set; }
    
        public virtual KeyAccount KeyAccount { get; set; }
        public virtual Offer Offer { get; set; }
        public virtual User User { get; set; }
        public virtual UserVoucher UserVoucher { get; set; }
        public virtual Voucher Voucher { get; set; }
    }
}
