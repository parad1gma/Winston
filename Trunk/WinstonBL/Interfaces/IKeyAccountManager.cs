using System.Collections.Generic;
using Winston.Common;
using Winston.Models;

namespace Winston.BL.Interfaces
{
    public interface IKeyAccountManager
    {

        IResponse<KeyAccountCreateModel> NewKeyAccountModel();
        IResponse<NoValue> AddKeyAccount(KeyAccountCreateModel createModel);
        List<KeyAccountViewModel> GetKeyAccounts();
        IResponse<KeyAccountCreateModel> GetKeyAccount(long id);
        IResponse<NoValue> UpdateKeyAccount(KeyAccountCreateModel model);
        IResponse<NoValue> DeleteKeyAccount(long id);
    }
}
