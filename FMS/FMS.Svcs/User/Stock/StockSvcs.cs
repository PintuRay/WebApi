using FMS.Db.Entity;
using FMS.Repo.User.Stock;
using FMS.Svcs.Email;

namespace FMS.Svcs.User.Stock
{
    public class StockSvcs(IStockRepo stockRepo, IEmailSvcs emailSvc) : IStockSvcs
    {
        #region Dependancy
        private readonly IStockRepo _stockRepo = stockRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Stock 
        #region Crud
        public async Task<SvcsBase> GetStocks()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> CreateStock(StockModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> UpdateStock(Guid Id, StockModel data, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RemoveStock(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedStock()
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverStock(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> RecoverAllStock(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteStock(Guid Id, AppUser user)
        {
            throw new NotImplementedException();
        }
        public async Task<SvcsBase> DeleteAllStock(List<string> Ids, AppUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
