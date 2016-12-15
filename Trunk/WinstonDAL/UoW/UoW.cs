using Winston.DAL.Interfaces;
using Winston.DAL.Repository;

namespace Winston.DAL.UoW
{
    public class UoW : IUoW
    {
        private readonly WinstonEntities _entity;
        public UoW(IWinstonEntities entity)
        {
            _entity = entity as WinstonEntities;


            Users = new UserRepository(entity);
            Offers = new OfferRepository(entity);
            Vouchers = new VoucherRepository(entity);
            UserVouchers = new UserVoucherRepository(entity);
            KeyAccounts = new KeyAccountRepository(entity);
            VoucherTransactions = new VoucherTransactionRepository(entity);
            UserSegments = new UserSegmentRepository(entity);

        }

        public IUserRepository Users { get; set; }
        public IOfferRepository Offers { get; set; }
        public IVoucherRepository Vouchers { get; set; }
        public IUserVoucherRepository UserVouchers { get; set; }
        public IKeyAccountRepository KeyAccounts { get; set; }
        public IVoucherTransactionRepository VoucherTransactions { get; set; }
        public IUserSegmentRepository UserSegments { get; set; }

        public int Complete()
        {
            return _entity.SaveChanges();
        }

        public void Dispose()
        {
            _entity.Dispose();
        }

    }
}
