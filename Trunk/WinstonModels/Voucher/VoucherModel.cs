using System;

namespace Winston.Models
{
    public class VoucherModel
    {
        public long VoucherID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Images { get; set; }
        public int PointCost { get; set; }
        public int Type { get; set; }
        public int Amount { get; set; }
        public int CalculationType { get; set; }
        public DateTime ExpirationDate { get; set; }
        public long KeyAcountID { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
