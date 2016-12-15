using Winston.DAL.Interfaces;

namespace Winston.DAL.Repository
{
    public class UserSegmentRepository : Repository<UserSegment>, IUserSegmentRepository
    {
        private IWinstonEntities _sbEntity
        {
            get { return Context as WinstonEntities; }
        }
        public UserSegmentRepository(IWinstonEntities context) : base(context as WinstonEntities)
        {
        }


    }
}
