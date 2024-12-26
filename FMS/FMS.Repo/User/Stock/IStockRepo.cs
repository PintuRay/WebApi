using FMS.Db.Entity;

namespace FMS.Repo.User.Stock
{
    public interface IStockRepo
    {
        #region Stock 
        #region Crud
        //Task<Result<Db.Entity.Stock>> GetStocks();
        //Task<RepoBase> CreateStock(StockModel data, AppUser user);
        //Task<RepoBase> UpdateStock(Guid Id, StockModel data, AppUser user);
        //Task<RepoBase> RemoveStock(Guid Id, AppUser user);
        #endregion
        #region Recover
        //Task<Result<Db.Entity.Stock>> GetRemovedStock();
        //Task<RepoBase> RecoverStock(Guid Id, AppUser user);
        //Task<RepoBase> DeleteStock(Guid Id, AppUser user);
        //Task<RepoBase> RecoverAllStock(List<string> Ids, AppUser user);
        //Task<RepoBase> DeleteAllStock(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
