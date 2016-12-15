using Winston.DAL.Interfaces;

namespace Winston.DAL.Repository
{
    public class VoucherRepository : Repository<Voucher>, IVoucherRepository
    {
        private IWinstonEntities _sbEntity
        {
            get { return Context as WinstonEntities; }
        }
        public VoucherRepository(IWinstonEntities context) : base(context as WinstonEntities)
        {
        }


    }
}
