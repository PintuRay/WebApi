using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;

namespace FMS.Repo.Accounting.Receipt
{
    public class ReceiptRepo(Context ctx, IMapper mapper, ICustomCache cache) : IReceiptRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly ICustomCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(30);
        #endregion
        #region Receipt
        public async Task<RepoBase> GetReceiptVoucherNo(string CashBank) { throw new NotImplementedException(); }
        #region Crud
        public async Task<RepoBase> CreateRecipt(ReceiptOrderModel data) { throw new NotImplementedException(); }
        public async Task<Result<ReceiptOrder>> GetReceipts() { throw new NotImplementedException(); }
        public async Task<RepoBase> GetReceiptById(string Id) { throw new NotImplementedException(); }
        public async Task<RepoBase> RemoveReceipt(string Id) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        public async Task<Result<ReceiptOrder>> GetRemovedReceipt() { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverReceipt(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteReceipt(Guid Id, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> RecoverAllReceipt(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        public async Task<RepoBase> DeleteAllReceipt(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
