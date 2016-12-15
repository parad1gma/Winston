using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using Winston.BL.Interfaces;
using Winston.Common;
using Winston.Models;

namespace Winston.Admin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: User
        public ActionResult Index()
        {

            var result = _userManager.GetUsers();
            return View(result);
        }

        // GET: User/Details/5
        public ActionResult Details(long id)
        {
            UserDetailsModel model = _userManager.GetDetails(id);

            return View(model);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            var result = _userManager.NewUserModel();
            return View(result);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserCreateModel createModel)
        {
            var userId = User.Identity.GetUserId();
            var result = _userManager.AddUser(createModel, userId);
            return Json(result);
        }

        [HttpPost]
        public ActionResult CreateUserVoucher(UserVoucherCreateModel model)
        {
            IResponse<NoValue> result = _userManager.AddUserVoucher(model);
            return Json(result);
        }

        [HttpPost]
        public ActionResult AddPointBalance(long userId, string code)
        {
            IResponse<NoValue> result = _userManager.AddPointBalance(userId, code);
            return Json(result);
        }
    }
}
