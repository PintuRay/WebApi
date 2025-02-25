using FMS.Db.Entity;
using FMS.Model.Account.Authentication;

namespace FMS.Repo.Account.AutherIzation
{
    public interface IAutherizationRepo
    {
        Task<RepoBase> GetUserById(string Id);
    }
}
