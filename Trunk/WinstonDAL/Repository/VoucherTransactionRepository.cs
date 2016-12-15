using Winston.DAL.Interfaces;

namespace Winston.DAL.Repository
{
    public class VoucherTransactionRepository : Repository<VoucherTransaction>, IVoucherTransactionRepository
    {

        private IWinstonEntities _sbEntity
        {
            get { return Context as WinstonEntities; }
        }
        public VoucherTransactionRepository(IWinstonEntities context) : base(context as WinstonEntities)
        {
        }

    }
}
