using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;

namespace FMS.Repo.Transaction.SalesReturn
{
    public class SalesReturnRepo(Context ctx, IMapper mapper, ICustomCache cache) : ISalesReturnRepo
    {

        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly ICustomCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region Sales Return
        public async Task<RepoBase> GetLastSalesReturnTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<RepoBase> CreateSaleReturnTransaction(SalesReturnOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<Result<SalesReturnOrder>> GetSaleReturnTransactions() { throw new NotImplementedException(); }
        public async Task<Result<SalesReturnOrder>> GetSaleReturnTransactionById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateSaleReturnTransaction(Guid Id, SalesReturnOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveSaleReturnTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<SalesReturnOrder>> GetRemovedSaleReturnTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverSaleReturnTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteSaleReturnTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllSaleReturnTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllSaleReturnTransaction(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
