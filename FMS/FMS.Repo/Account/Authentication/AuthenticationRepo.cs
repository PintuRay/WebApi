using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;
namespace FMS.Repo.Account.Authentication
{
    public class AuthenticationRepo(
        Context ctx, IMapper mapper
    ) : IAuthenticationRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        #endregion
        #region  SignUp Token
        public async Task<Result<RegisterToken>> ValidateToken(string data)
        {
            Result<RegisterToken> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from rt in _ctx.RegisterTokens
                                   join au in _ctx.AppUsers on rt.TokenId equals au.Fk_TokenId into auGroup
                                   from au in auGroup.DefaultIfEmpty()
                                   where rt.TokenValue == data && au == null
                                   select new RegisterToken
                                   {
                                       TokenId = rt.TokenId,
                                       TokenValue = rt.TokenValue
                                   }).SingleOrDefaultAsync();
                if (Query != null)
                {
                    _Result.SingleObjData = Query;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<bool> IsPhoneNumberInUse(string PhoneNumber)
        {
            Result<bool> _Result = new();
            try
            {
                var Query = await _ctx.AppUsers.Where(s => s.PhoneNumber == PhoneNumber).Select(s => s.PhoneNumber).SingleOrDefaultAsync();
                if (Query != null)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }
            return false;
        }

        public async Task<bool> IsUserNameExist(string userName)
        {
            Result<bool> _Result = new();
            try
            {
                var Query = await _ctx.AppUsers.Where(s => s.UserName == userName).Select(s => s.UserName).SingleOrDefaultAsync();
                if (Query != null)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }
            return false;
        }
        #endregion
        #region Address
        public async Task<RepoBase> CreateUserAdress(AddressModel data, AppUser user)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var newAddress = _mapper.Map<Address>(data);
                newAddress.Fk_UserId = user.Id;
                newAddress.CreatedDate = DateTime.UtcNow;
                newAddress.CreatedBy = user.Name;
                await _ctx.Addresses.AddAsync(newAddress);
                int Count = await _ctx.SaveChangesAsync();
                if (Count > 0)
                {
                    _Result.Id = newAddress.AddressId.ToString();
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        #endregion
    }
}
