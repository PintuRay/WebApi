using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;

namespace FMS.Repo.Accounting.Payment
{
    public class PaymentRepo(Context ctx, IMapper mapper, IRedisCache cache) : IPaymentRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(3);
        #endregion
        #region Payment
        //public async Task<RepoBase> GetPaymentVoucherNo(string CashBank) { throw new NotImplementedException(); }
        #region Crud
        //public async Task<RepoBase> CreatePayment(PaymentOrderModel data) { throw new NotImplementedException(); }
        //public async Task<Result<PaymentOrder>> GetPayments() { throw new NotImplementedException(); }
        //public async Task<RepoBase> GetPaymentById(string Id) { throw new NotImplementedException(); }
        //public async Task<RepoBase> RemovePayment(string Id) { throw new NotImplementedException(); }
        #endregion
        #region Recover
        //public async Task<Result<PaymentOrder>> GetRemovedPayment() { throw new NotImplementedException(); }
        //public async Task<RepoBase> RecoverPayment(Guid Id, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> DeletePayment(Guid Id, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> RecoverAllPayment(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        //public async Task<RepoBase> DeleteAllPayment(List<string> Ids, AppUser user) { throw new NotImplementedException(); }
        #endregion
        #endregion
    }
}
