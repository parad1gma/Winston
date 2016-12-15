using System.Collections.Generic;
using System.Web.Http;
using Winston.BL.Interfaces;
using Winston.Models;

namespace Winston.API.Controllers
{
    public class UserSegmentController : ApiController
    {
        private readonly IUserSegmentManager _userSegmentManager;

        public UserSegmentController(IUserSegmentManager userSegmentManager)
        {
            _userSegmentManager = userSegmentManager;
        }

        [HttpGet, Route("api/UserSegment/Index")]
        public List<UserSegmentViewModel> Index()
        {
            var result = _userSegmentManager.GetUserSegments();
            return result;
        }

    }
}
