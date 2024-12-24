using FMS.Db.Entity;

namespace FMS.Repo.Admin.LabourRate
{
    public interface ILabourRateRepo
    {
        #region Labour Rate
        #region Crud
        Task<Result<Db.Entity.LabourRate>> GetAllLabourRates(Guid FinancialYearId, Guid BranchId);
        Task<RepoBase> CreateLabourRate(LabourRateModel data, AppUser user);
        Task<RepoBase> UpdateLabourRate(Guid Id, LabourRateModel data, AppUser user);
        Task<RepoBase> RemoveLabourRate(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<Result<Db.Entity.LabourRate>> GetRemovedLabourRate(Guid FinancialYearId, Guid BranchId);
        Task<RepoBase> RecoverLabourRate(Guid Id, AppUser user);
        Task<RepoBase> DeleteLabourRate(Guid Id, AppUser user);
        Task<RepoBase> RecoverAllLabourRate(List<string> Ids, AppUser user);
        Task<RepoBase> DeleteAllLabourRate(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
