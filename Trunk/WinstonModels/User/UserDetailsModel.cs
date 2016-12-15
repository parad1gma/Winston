using System.Collections.Generic;
using Winston.Common;

namespace Winston.Models
{
    public class UserDetailsModel
    {
        public IResponse<UserViewModel> UserDetails { get; set; }
        public IResponse<List<VoucherViewModel>> Vouchers { get; set; }
        public IResponse<List<UserVoucherViewModel>> UserVouchers { get; set; }
    }
}
