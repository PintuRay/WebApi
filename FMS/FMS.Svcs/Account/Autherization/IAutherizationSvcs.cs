using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Account.Authentication;
using FMS.Model.Account.Autherization;
using FMS.Repo;
using System.Threading.Tasks;

namespace FMS.Svcs.Account.Autherization
{
    public interface IAutherizationSvcs
    {
        #region Role
        Task<SvcsBase> CreateRole(AppRole model);
        Task<SvcsBase> GetRoles();
        Task<SvcsBase> GetRoleById(string Id);
        Task<SvcsBase> UpdateRole(string Id, AppRole model);
        Task<SvcsBase> DeleteRole(string Id);
        #endregion
        #region User-Role && Claims
        Task<SvcsBase> GetAllUserWithRolesAndClaims();
        Task<SvcsBase> GetUserWithRolesAndClaims(string RoleId);
        Task<SvcsBase> UpdateUserRoleAndClaims(UserRoleClaimModel model);
        #endregion    
    }
}
