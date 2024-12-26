using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;

namespace FMS.Repo.User.LedgerBalance
{
    public class LedgerBalanceRepo(Context ctx, IMapper mapper, IRedisCache cache) : ILedgerBalanceRepo
    {

        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region LedgerBalance
        #region Crud
        public async Task<Result<Db.Entity.LedgerBalance>> GetLedgerBalances() { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateLedgerBalance(LedgerBalanceModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateLedgerBalance(Guid Id, LedgerBalanceModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveLedgerBalance(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<Db.Entity.LedgerBalance>> GetRemovedLedgerBalance() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverLedgerBalance(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteLedgerBalance(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllLedgerBalance(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllLedgerBalance(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
