using System.Collections.Generic;
using Winston.Common;

namespace Winston.DAL.Interfaces
{
    public interface IOfferRepository : IRepository<Offer>
    {
        IPagedResult<IEnumerable<Offer>> GetOffers(IPage page);
    }
}
