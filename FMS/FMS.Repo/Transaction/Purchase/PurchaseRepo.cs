using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;

namespace FMS.Repo.Transaction.Purchase
{
    public class PurchaseRepo(Context ctx, IMapper mapper, IRedisCache cache) : IPurchaseRepo
    {

        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region Purchase
        //public async Task<RepoBase> GetLastPurchaseTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        //public async Task<Result<PurchaseOrder>> GetPurchaseTransactions() { throw new NotImplementedException(); }
        //public async Task<Result<PurchaseOrder>> GetPurchaseTransactionById(Guid Id) { throw new NotImplementedException(); }
        //public async Task<RepoBase> CreatePurchaseTransaction(PurchaseOrderModel data, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> UpdatePurchaseTransaction(Guid Id, PurchaseOrderModel data, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> RemovePurchaseTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        //public async Task<Result<PurchaseOrder>> GetRemovedPurchaseTransactions() { throw new NotImplementedException(); }
        //public async Task<RepoBase> RecoverPurchaseTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> DeletePurchaseTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> RecoverAllPurchaseTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> DeleteAllPurchaseTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
