using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;

namespace FMS.Repo.Transaction.Service
{
    public class ServiceRepo(Context ctx, IMapper mapper, IRedisCache cache) : IServiceRepo
    {

        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region Service
        //public async Task<RepoBase> GetLastServiceTransactionNo() { throw new NotImplementedException(); }
        #region Crud
        //public async Task<Result<LabourOrder>> GetServiceTransactions() { throw new NotImplementedException(); }
        //public async Task<RepoBase> CreateServiceTransaction(LabourOrderModel data, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> UpdateServiceTransaction(Guid Id, LabourOrderModel data, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> RemoveServiceTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        //public async Task<Result<LabourOrder>> GetRemovedServiceTransactions() { throw new NotImplementedException(); }
        //public async Task<RepoBase> RecoverServiceTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> DeleteServiceTransaction(Guid Id, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> RecoverAllServiceTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> DeleteAllServiceTransactions(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
