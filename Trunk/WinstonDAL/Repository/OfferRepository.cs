using System.Collections.Generic;
using System.Linq;
using Winston.Common;
using Winston.DAL.Interfaces;

namespace Winston.DAL.Repository
{
    public class OfferRepository : Repository<Offer>, IOfferRepository
    {

        private IWinstonEntities _sbEntity
        {
            get { return Context as WinstonEntities; }
        }
        public OfferRepository(IWinstonEntities context) : base(context as WinstonEntities)
        {
        }

        public IPagedResult<IEnumerable<Offer>> GetOffers(IPage page)
        {
            var query = _sbEntity.Offer;

            return new PagedResult<IEnumerable<Offer>>()
            {
                TotalCount = query.Count(),
                Value = query.OrderBy(o => o.OfferID).Skip(page.Skip).Take(page.PageSize)
            };
        }
    }
}
