using Winston.DAL.Interfaces;

namespace Winston.DAL.Repository
{
    public class UserVoucherRepository : Repository<UserVoucher>, IUserVoucherRepository
    {

        private IWinstonEntities _sbEntity
        {
            get { return Context as WinstonEntities; }
        }
        public UserVoucherRepository(IWinstonEntities context) : base(context as WinstonEntities)
        {
        }

    }
}
