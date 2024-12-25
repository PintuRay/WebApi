using FMS.Db.Entity;

namespace FMS.Svcs.User.Stock
{
    public interface IStockSvcs
    {
        #region Stock 
        #region Crud
        Task<SvcsBase> GetStocks();
        Task<SvcsBase> CreateStock(StockModel data, AppUser user);
        Task<SvcsBase> UpdateStock(Guid Id, StockModel data, AppUser user);
        Task<SvcsBase> RemoveStock(Guid Id, AppUser user);
        #endregion
        #region Recover
        Task<SvcsBase> GetRemovedStock();
        Task<SvcsBase> RecoverStock(Guid Id, AppUser user);
        Task<SvcsBase> DeleteStock(Guid Id, AppUser user);
        Task<SvcsBase> RecoverAllStock(List<string> Ids, AppUser user);
        Task<SvcsBase> DeleteAllStock(List<string> Ids, AppUser user);
        #endregion
        #endregion
    }
}
