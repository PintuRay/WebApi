using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;

namespace FMS.Repo.User.Stock
{
    public class StockRepo(Context ctx, IMapper mapper, ICustomCache cache) : IStockRepo
    {

        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly ICustomCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region Stock 
        #region Crud
        public async Task<Result<Db.Entity.Stock>> GetStocks() { throw new NotImplementedException(); }
        public async Task<RepoBase> CreateStock(StockModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> UpdateStock(Guid Id, StockModel data, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveStock(Guid Id, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<Db.Entity.Stock>> GetRemovedStock() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverStock(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteStock(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllStock(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllStock(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
