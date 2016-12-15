using System.Web.Mvc;
using Winston.BL.Interfaces;
using Winston.Common;
using Winston.Models;

namespace Winston.Admin.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class VoucherController : Controller
    {
        private readonly IVoucherManager _voucherManager;

        public VoucherController(IVoucherManager voucherManager)
        {
            _voucherManager = voucherManager;
        }

        // GET: Voucher
        public ActionResult Index()
        {
            var result = _voucherManager.GetVouchers();
            return View(result);
        }

        // GET: Voucher/Details/5
        public ActionResult Details(long id)
        {
            var result = _voucherManager.GetVoucher(id);
            return View(result);
        }

        // GET: Voucher/Create
        public ActionResult Create()
        {
            var result = _voucherManager.NewVoucherModel();
            return View(result);
        }

        // POST: Voucher/Create
        [HttpPost]
        public ActionResult Create(VoucherCreateModel createModel)
        {

            var result = _voucherManager.AddVoucher(createModel);
            return Json(result);
        }

        // GET: Voucher/Edit/5
        public ActionResult Edit(long id)
        {
            var result = _voucherManager.GetVoucher(id);
            return View(result);
        }

        // POST: Voucher/Edit/5
        [HttpPost]
        public ActionResult Edit(VoucherCreateModel model)
        {
            var result = _voucherManager.UpdateVaucher(model);
            return Json(result);

        }

        // POST: Voucher/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var result = _voucherManager.DeleteVoucher(id);
            return Json(result);
        }
    }
}
