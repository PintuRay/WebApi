using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;

namespace FMS.Repo.User.SubLedgerBalance
{
    public class SubLedgerBalanceRepo(Context ctx, IMapper mapper, IRedisCache cache) : ISubLedgerBalanceRepo
    {

        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region SubLedger Balance
        #region Crud
        public async Task<Result<Db.Entity.SubLedgerBalance>> GetSubLedgerBalances() { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateSubLedgerBalance(SubLedgerBalanceModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateSubLedgerBalance(Guid Id, SubLedgerBalanceModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveSubLedgerBalance(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<Db.Entity.SubLedgerBalance>> GetRemovedSubLedgerBalance() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverSubLedgerBalance(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteSubLedgerBalance(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllSubLedgerBalance(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllSubLedgerBalance(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
