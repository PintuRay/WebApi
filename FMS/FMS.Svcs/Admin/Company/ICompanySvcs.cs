using FMS.Db.Entity;

namespace FMS.Svcs.Admin.Company
{
    public interface ICompanySvcs
    {
        #region Company
        #region Crud
        //Task<SvcsBase> GetCompany(string BranchId);
        //Task<SvcsBase> CreateCompany(CompanyModel data, AppUser user);
        //Task<SvcsBase> UpdateCompany(Guid Id, CompanyModel model, AppUser user);
        //Task<SvcsBase> RemoveCompany(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<SvcsBase> GetRemovedCompanies(string BranchId);
        //Task<SvcsBase> RecoverCompany(Guid Id, AppUser user);
        //Task<SvcsBase> DeleteCompany(Guid Id, AppUser user);
        //Task<SvcsBase> RecoverAllCompany(List<string> Ids, AppUser user);
        //Task<SvcsBase> DeleteAllCompany(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
