using System.Collections.Generic;
using Winston.Common;
using Winston.Models;

namespace Winston.BL.Interfaces
{
    public interface IUserManager
    {
        IResponse<UserCreateModel> NewUserModel();
        IResponse<NoValue> AddUser(UserCreateModel createModel, string userId);
        IResponse<UserViewModel> GetUser(long id);
        List<UserViewModel> GetUsers();
        IResponse<List<UserVoucherViewModel>> GetUserVouchers(long id);
        UserDetailsModel GetDetails(long id);
        IResponse<NoValue> AddUserVoucher(UserVoucherCreateModel model);
        IResponse<NoValue> AddPointBalance(long id, string code);
    }
}