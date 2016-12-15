using System.Collections.Generic;
using System.Web.Http;
using Winston.BL.Interfaces;
using Winston.Models;

namespace Winston.API.Controllers
{
    public class OfferController : ApiController
    {
        private readonly IOfferManager _offerManager;

        public OfferController(IOfferManager offerManager)
        {
            _offerManager = offerManager;
        }

        // GET: api/Offer/Index
        [HttpGet, Route("api/Offer/Index")]
        public List<OfferViewModel> Index()
        {
            var result = _offerManager.GetOffers();
            return result;
        }

    }
}
