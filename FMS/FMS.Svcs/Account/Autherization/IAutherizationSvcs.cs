using FMS.Model;
using FMS.Model.Account.Authentication;
using FMS.Model.Account.Autherization;
using FMS.Repo;

namespace FMS.Svcs.Account.Autherization
{
    public interface IAutherizationSvcs
    {
        #region Role
        Task<Base> CreateRole(RoleModel model);
        Task<Base> GetRoles();
        Task<Base> GetRoleById(string Id);
        Task<Base> UpdateRole(string Id, RoleModel model);
        Task<Base> DeleteRole(string Id);
        #endregion
        #region User-Role && Claims
        Task<Base> GetUserInRoleWithClaims(string RoleId);
        Task<Base> UpdateUserRoleAndClaims(UserRoleClaimModel model);
        #endregion
    }
}
