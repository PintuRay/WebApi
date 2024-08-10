using FMS.Model;
using FMS.Model.Account.Authentication;
using FMS.Model.Account.Autherization;
using FMS.Repo;
using System.Threading.Tasks;

namespace FMS.Svcs.Account.Autherization
{
    public interface IAutherizationSvcs
    {
        #region User
        Task<Base> GetUsers();
        Task<Base> GetUserByMail(string email);
        Task<Base> GetUserById(string Id);
        Task<Base> UpdateUser(string Id, UserModel User);
        Task<Base> DeletUser(string UserId);
        #endregion
        #region Role
        Task<Base> CreateRole(RoleModel model);
        Task<Base> GetRoles();
        Task<Base> GetRoleById(string Id);
        Task<Base> UpdateRole(string Id, RoleModel model);
        Task<Base> DeleteRole(string Id);
        #endregion
        #region User-Role && Claims
        Task<Base> GetAllUserWithRolesAndClaims();
        Task<Base> GetUserWithRolesAndClaims(string RoleId);
        Task<Base> UpdateUserRoleAndClaims(UserRoleClaimModel model);
        #endregion
        
    }
}
