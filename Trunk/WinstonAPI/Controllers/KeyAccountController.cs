using System.Collections.Generic;
using System.Web.Http;
using Winston.BL.Interfaces;
using Winston.Models;

namespace Winston.API.Controllers
{
    public class KeyAccountController : ApiController
    {
        private readonly IKeyAccountManager _keyAccountManager;

        public KeyAccountController(IKeyAccountManager keyAccountManager)
        {
            _keyAccountManager = keyAccountManager;
        }

        // GET: api/KeyAccount/Index
        [HttpGet, Route("api/KeyAccount/Index")]
        public List<KeyAccountViewModel> Index()
        {
            var result = _keyAccountManager.GetKeyAccounts();
            return result;
        }


    }
}
