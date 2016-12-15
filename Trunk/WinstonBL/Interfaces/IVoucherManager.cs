using System.Collections.Generic;
using Winston.Common;
using Winston.Models;

namespace Winston.BL.Interfaces
{
    public interface IVoucherManager
    {
        IResponse<VoucherCreateModel> NewVoucherModel();

        IResponse<NoValue> AddVoucher(VoucherCreateModel createModel);


        IResponse<VoucherCreateModel> GetVoucher(long id);

        List<VoucherViewModel> GetVouchers();

        IResponse<NoValue> UpdateVaucher(VoucherCreateModel model);
        IResponse<NoValue> DeleteVoucher(long id);



    }
}
