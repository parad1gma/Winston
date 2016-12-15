using Winston.DAL.Interfaces;

namespace Winston.DAL.Repository
{
    public class KeyAccountRepository : Repository<KeyAccount>, IKeyAccountRepository
    {
        private IWinstonEntities _sbEntity
        {
            get { return Context as WinstonEntities; }
        }
        public KeyAccountRepository(IWinstonEntities context) : base(context as WinstonEntities)
        {
        }

    }
}
