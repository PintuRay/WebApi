using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;

namespace FMS.Repo.Transaction.InwardSupply
{
    public class InwardSupplyRepo(Context ctx, IMapper mapper, IRedisCache cache) : IInwardSupplyRepo
    {

        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region Inward Supply    
        public async Task<RepoBase> GetLastInwardSupplyTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        public async Task<Result<InwardSupplyOrder>> GetInwardSupplyTransactions() { throw new NotImplementedException(); }
        public async Task<Result<InwardSupplyOrder>> GetInwardSupplyTransactionById(Guid Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateInwardSupplyTransaction(InwardSupplyOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateInwardSupplyTransaction(Guid Id, InwardSupplyOrderModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveInwardSupplyTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<InwardSupplyOrder>> GetRemovedInwardSupplyTransactions() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverInwardSupplyTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteInwardSupplyTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllInwardSupplyTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllInwardSupplyTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
