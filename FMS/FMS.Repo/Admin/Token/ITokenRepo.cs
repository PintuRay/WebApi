using FMS.Db.Entity;

namespace FMS.Repo.Admin.Token
{
    public interface ITokenRepo
    {
        #region Generate SignUp Token
        Task<RepoBase> CreateToken(RegisterTokenModel model, AppUser user);
        #endregion
    }
}
