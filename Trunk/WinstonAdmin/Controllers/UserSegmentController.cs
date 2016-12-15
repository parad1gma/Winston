using System.Web.Mvc;
using Winston.BL.Interfaces;
using Winston.Common;
using Winston.Models;

namespace Winston.Admin.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class UserSegmentController : Controller
    {
        private readonly IUserSegmentManager _userSegmentManager;

        public UserSegmentController(IUserSegmentManager userSegmentmanager)
        {
            _userSegmentManager = userSegmentmanager;
        }

        // GET: UserSegment
        public ActionResult Index()
        {
            var result = _userSegmentManager.GetUserSegments();
            return View(result);
        }

        // GET: UserSegment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserSegment/Create
        public ActionResult Create()
        {
            var result = _userSegmentManager.NewUserSegmentModel();
            return View(result);
        }

        // POST: UserSegment/Create
        [HttpPost]
        public ActionResult Create(UserSegmentCreateModel createModel)
        {
            var result = _userSegmentManager.AddUserSegment(createModel);
            return Json(result);
        }

        // GET: UserSegment/Edit/5
        public ActionResult Edit(long id)
        {
            var result = _userSegmentManager.GetUserSegment(id);
            return View(result);
        }

        // POST: UserSegment/Edit/5
        [HttpPost]
        public ActionResult Edit(UserSegmentCreateModel model)
        {
            var result = _userSegmentManager.UpdateUserSegment(model);
            return Json(result);
        }

        // POST: UserSegment/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var result = _userSegmentManager.DeleteUserSegment(id);
            return Json(result);
        }
    }
}
