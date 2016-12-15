using System.Collections.Generic;
using System.Web.Http;
using Winston.BL.Interfaces;
using Winston.Common;
using Winston.Models;

namespace Winston.API.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: api/user/index
        [HttpGet, Route("api/User/Index")]
        public List<UserViewModel> Index()
        {
            var result = _userManager.GetUsers();
            return result;
        }

        [HttpGet, Route("api/User/Details")]
        public UserDetailsModel Details(long id)
        {
            UserDetailsModel model = _userManager.GetDetails(id);

            return model;
        }

        [HttpPost, Route("api/User/AddPointBalance")]
        public IResponse<NoValue> AddPointBalance(long userId, string code)
        {
            IResponse<NoValue> result = _userManager.AddPointBalance(userId, code);
            return result;
        }


        [HttpPost, Route("api/User/CreateUserVoucher")]
        public IResponse<NoValue> CreateUserVoucher(UserVoucherCreateModel model)
        {
            IResponse<NoValue> result = _userManager.AddUserVoucher(model);
            return result;
        }
    }
}
