using FMS.Db.Entity;
using FMS.Model;

namespace FMS.Svcs.Account.User
{
    public interface IUserSvcs
    {
        #region SignUp 
        Task<SvcsBase> ValidateToken(string Token);
        Task<SvcsBase> IsEmailInUse(string email);
        Task<SvcsBase> IsPhoneNumberInUse(string phoneNumber);
        Task<SvcsBase> IsUserNameExist(string userName);
        Task<SvcsBase> SignUp(UserModel data);
        #endregion
        #region User
        Task<SvcsBase> GetUsers();
        Task<SvcsBase> GetUsers(PaginationParams pagination);
        Task<SvcsBase> GetUserByMail(string email);
        Task<SvcsBase> GetUserById(string Id);
        Task<SvcsBase> UpdateUser(UserUpdateModel User);
        Task<SvcsBase> DeletUser(string UserId);
        #endregion
    }
}
