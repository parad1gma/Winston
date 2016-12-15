using Winston.DAL.Interfaces;

namespace Winston.DAL.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        private IWinstonEntities _sbEntity
        {
            get { return Context as WinstonEntities; }
        }
        public UserRepository(IWinstonEntities context) : base(context as WinstonEntities)
        {
        }


    }
}
