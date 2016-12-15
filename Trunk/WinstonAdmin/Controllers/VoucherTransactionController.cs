using System.Web.Mvc;
using Winston.BL.Interfaces;
using Winston.Common;
using Winston.Models;

namespace Winston.Admin.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class VoucherTransactionController : Controller
    {
        private readonly IVoucherTransactionManager _voucherTransactionManager;

        public VoucherTransactionController(IVoucherTransactionManager voucherTransactionManager)
        {
            _voucherTransactionManager = voucherTransactionManager;
        }

        // GET: VoucherTransaction
        public ActionResult Index()
        {
            return View();
        }

        // GET: VoucherTransaction/Create
        public ActionResult Create(long id)
        {
            IResponse<VoucherTransactionCreateModel> result = _voucherTransactionManager.NewVoucherTransactionModel(id);
            return View(result);
        }

        // POST: VoucherTransaction/Create
        [HttpPost]
        public ActionResult Create(VoucherTransactionCreateModel model)
        {
            IResponse<NoValue> result = _voucherTransactionManager.AddVoucherTransaction(model);
            return Json(result);
        }

    }
}
