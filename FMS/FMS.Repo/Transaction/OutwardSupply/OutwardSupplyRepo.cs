using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;

namespace FMS.Repo.Transaction.OutwardSupply
{
    public class OutwardSupplyRepo(Context ctx, IMapper mapper, IRedisCache cache) : IOutwardSupplyRepo
    {

        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region Outward Supply
        //public async Task<RepoBase> GetLastOutwardSupplyTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        //public async Task<Result<OutwardSupplyOrder>> GetOutwardSupplyTransactions() { throw new NotImplementedException(); }
        //public async Task<Result<OutwardSupplyOrder>> GetOutwardSupplyTransactionById(Guid Id) { throw new NotImplementedException(); }
        //public async Task<RepoBase> CreateOutwardSupplyTransaction(OutwardSupplyOrderModel data, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> UpdateOutwardSupplyTransaction(Guid Id, OutwardSupplyOrderModel data, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> RemoveOutwardSupplyTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        //public async Task<Result<OutwardSupplyOrder>> GetRemovedOutwardSupplyTransactions() { throw new NotImplementedException(); }
        //public async Task<RepoBase> RecoverOutwardSupplyTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> DeleteOutwardSupplyTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> RecoverAllOutwardSupplyTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> DeleteAllOutwardSupplyTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
