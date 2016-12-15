using System.Collections.Generic;
using Winston.Common;
using Winston.Models;

namespace Winston.BL.Interfaces
{
    public interface IOfferManager
    {
        IResponse<OfferCreateModel> NewOfferModel();
        IResponse<NoValue> AddOffer(OfferCreateModel model);
        List<OfferViewModel> GetOffers();
        IResponse<OfferViewModel> GetOffer(long id);
        IResponse<OfferCreateModel> EditOffer(int id);
        IResponse<NoValue> UpdateOffer(OfferCreateModel model);
        IResponse<NoValue> DeleteOffer(long id);

    }
}