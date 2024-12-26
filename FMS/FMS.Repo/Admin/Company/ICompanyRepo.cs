using FMS.Db.Entity;

namespace FMS.Repo.Admin.Company
{
    public interface ICompanyRepo
    {
        #region Company
        #region Crud
        //Task<Result<Db.Entity.Company>> GetCompany(string BranchId);
        //Task<RepoBase> CreateCompany(CompanyModel data, AppUser user);
        //Task<RepoBase> UpdateCompany(Guid Id, CompanyModel model, AppUser user);
        //Task<RepoBase> RemoveCompany(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<Db.Entity.Company>> GetRemovedCompanies(string BranchId);
        //Task<RepoBase> RecoverCompany(Guid Id, AppUser user);
        //Task<RepoBase> DeleteCompany(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllCompany(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllCompany(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
