using System.Web.Mvc;
using Winston.BL.Interfaces;
using Winston.Common;
using Winston.Models;

namespace Winston.Admin.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class KeyAccountController : Controller
    {

        private readonly IKeyAccountManager _keyAccountManager;

        public KeyAccountController(IKeyAccountManager keyAccountManager)
        {
            _keyAccountManager = keyAccountManager;
        }

        // GET: KeyAccount
        public ActionResult Index()
        {
            var result = _keyAccountManager.GetKeyAccounts();
            return View(result);
        }

        // GET: KeyAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: KeyAccount/Create
        public ActionResult Create()
        {
            var result = _keyAccountManager.NewKeyAccountModel();
            return View(result);
        }

        // POST: KeyAccount/Create
        [HttpPost]
        public ActionResult Create(KeyAccountCreateModel createModel)
        {
            var result = _keyAccountManager.AddKeyAccount(createModel);
            return Json(result);
        }

        // GET: KeyAccount/Edit/5
        public ActionResult Edit(long id)
        {
            var result = _keyAccountManager.GetKeyAccount(id);
            return View(result);
        }

        // POST: KeyAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(KeyAccountCreateModel model)
        {
            var result = _keyAccountManager.UpdateKeyAccount(model);
            return Json(result);
        }

        // POST: KeyAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            var result = _keyAccountManager.DeleteKeyAccount(id);
            return Json(result);
        }
    }
}
