using System;
using Winston.DAL.Interfaces;

namespace Winston.DAL.UoW
{
    public interface IUoW : IDisposable
    {
        IUserRepository Users { get; set; }
        IOfferRepository Offers { get; set; }
        IVoucherRepository Vouchers { get; set; }
        IUserVoucherRepository UserVouchers { get; set; }
        IKeyAccountRepository KeyAccounts { get; set; }
        IVoucherTransactionRepository VoucherTransactions { get; set; }
        IUserSegmentRepository UserSegments { get; set; }

        int Complete();

    }
}
