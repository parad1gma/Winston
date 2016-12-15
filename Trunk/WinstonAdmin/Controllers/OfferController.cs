using System.Collections.Generic;
using System.Web.Mvc;
using Winston.BL.Interfaces;
using Winston.Common;
using Winston.Models;

namespace Winston.Admin.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class OfferController : Controller
    {

        private readonly IOfferManager _offerManager;

        public OfferController(IOfferManager offerManager)
        {
            _offerManager = offerManager;
        }

        // GET: Offer
        public ActionResult Index()
        {
            var model = new PagedResponse<List<OfferViewModel>>()
            {
                Value = _offerManager.GetOffers()
            };

            return View(model);
        }

        // GET: Offer/Details/5
        public ActionResult Details(int id)
        {
            IResponse<OfferViewModel> result = _offerManager.GetOffer(id);
            return View(result);
        }

        // GET: Offer/Create
        public ActionResult Create()
        {
            IResponse<OfferCreateModel> result = _offerManager.NewOfferModel();
            return View(result);
        }

        // POST: Offer/Create
        [HttpPost]
        public ActionResult Create(OfferCreateModel createModel)
        {
            IResponse<NoValue> result = _offerManager.AddOffer(createModel);
            return Json(result);
        }

        // GET: Offer/Edit/5
        public ActionResult Edit(int id)
        {
            IResponse<OfferCreateModel> result = _offerManager.EditOffer(id);
            return View(result);
        }

        // POST: Offer/Edit/5
        [HttpPost]
        public ActionResult Edit(OfferCreateModel model)
        {
            IResponse<NoValue> result = _offerManager.UpdateOffer(model);
            return Json(result);
        }

        // POST: Offer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            IResponse<NoValue> result = _offerManager.DeleteOffer(id);
            return Json(result);
        }
    }
}
