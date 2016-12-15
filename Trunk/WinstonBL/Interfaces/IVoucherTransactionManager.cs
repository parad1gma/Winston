using Winston.Common;
using Winston.Models;

namespace Winston.BL.Interfaces
{
    public interface IVoucherTransactionManager
    {
        IResponse<VoucherTransactionCreateModel> NewVoucherTransactionModel(long id);
        IResponse<NoValue> AddVoucherTransaction(VoucherTransactionCreateModel model);
    }
}
