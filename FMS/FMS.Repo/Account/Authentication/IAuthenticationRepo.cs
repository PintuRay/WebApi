using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Admin;
using Microsoft.AspNetCore.Identity;

namespace FMS.Repo.Account.Authentication
{
    public interface IAuthentication
    {
        #region  SignUp Token
        Task<Result<RegisterTokenViewModel>> ValidateToken(string data);
        #endregion
    }
}
