namespace FMS.Repo.Account.User
{
    public interface IUserRepo
    {
        #region  SignUp
        Task<RepoBase> ValidateToken(string data);
        Task<bool> IsPhoneNumberInUse(string phoneNumber);
        Task<bool> IsUserNameExist(string userName);
        #endregion
        Task<RepoBase> GetUserById(string Id);
    }
}
