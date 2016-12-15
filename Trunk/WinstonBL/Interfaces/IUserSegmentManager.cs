using System.Collections.Generic;
using Winston.Common;
using Winston.Models;

namespace Winston.BL.Interfaces
{
    public interface IUserSegmentManager
    {
        IResponse<UserSegmentCreateModel> NewUserSegmentModel();
        IResponse<NoValue> AddUserSegment(UserSegmentCreateModel createModel);
        List<UserSegmentViewModel> GetUserSegments();
        IResponse<UserSegmentCreateModel> GetUserSegment(long id);
        IResponse<NoValue> UpdateUserSegment(UserSegmentCreateModel model);
        IResponse<NoValue> DeleteUserSegment(long id);
    }
}
