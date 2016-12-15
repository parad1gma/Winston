using System.Web.Http;
using Winston.BL.Interfaces;
using Winston.Common;
using Winston.Models;

namespace Winston.API.Controllers
{
    public class VoucherTransactionController : ApiController
    {
        private readonly IVoucherTransactionManager _voucherTransactionManager;

        public VoucherTransactionController(IVoucherTransactionManager voucherTransactionManager)
        {
            _voucherTransactionManager = voucherTransactionManager;
        }

        [HttpGet, Route("api/KeyAccount/GetTransaction")]
        public IResponse<VoucherTransactionCreateModel> Create(long id)
        {
            IResponse<VoucherTransactionCreateModel> result = _voucherTransactionManager.NewVoucherTransactionModel(id);
            return result;
        }

        // POST: VoucherTransaction/Create
        [HttpPost, Route("api/KeyAccount/CreateTransaction")]
        public IResponse<NoValue> Create(VoucherTransactionCreateModel model)
        {
            IResponse<NoValue> result = _voucherTransactionManager.AddVoucherTransaction(model);
            return result;
        }

    }
}
