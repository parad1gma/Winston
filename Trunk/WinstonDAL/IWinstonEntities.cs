using System.Data.Entity;

namespace Winston.DAL
{
    public interface IWinstonEntities
    {
        DbSet<AspNetRoles> AspNetRoles { get; set; }
        DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        DbSet<AspNetUsers> AspNetUsers { get; set; }
        DbSet<Offer> Offer { get; set; }
        DbSet<User> User { get; set; }
        DbSet<Voucher> Voucher { get; set; }
        DbSet<UserVoucher> UserVoucher { get; set; }
        DbSet<VoucherTransaction> VoucherTransaction { get; set; }
        DbSet<CalculationTypeEnum> CalculationTypeEnum { get; set; }
        DbSet<VoucherTypeEnum> VoucherTypeEnum { get; set; }
        DbSet<KeyAccount> KeyAccount { get; set; }
        DbSet<UserSegment> UserSegment { get; set; }
    }
}
