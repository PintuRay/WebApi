using FMS.Db.Entity;
namespace FMS.Repo.Account.Authentication
{
    public interface IAuthenticationRepo
    {
        #region  SignUp Token
        Task<RepoBase> ValidateToken(string data);
        Task<bool> IsPhoneNumberInUse(string phoneNumber);
        Task<bool> IsUserNameExist(string userName);
        #endregion
    }
}
