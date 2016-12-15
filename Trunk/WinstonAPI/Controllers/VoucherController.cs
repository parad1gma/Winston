using System.Collections.Generic;
using System.Web.Http;
using Winston.BL.Interfaces;
using Winston.Models;

namespace Winston.API.Controllers
{
    public class VoucherController : ApiController
    {
        private readonly IVoucherManager _voucherManager;

        public VoucherController(IVoucherManager voucherManager)
        {
            _voucherManager = voucherManager;
        }

        // GET: api/Voucher/Index
        [HttpGet, Route("api/Voucher/Index")]
        public List<VoucherViewModel> Index()
        {
            var result = _voucherManager.GetVouchers();
            return result;
        }

    }
}
