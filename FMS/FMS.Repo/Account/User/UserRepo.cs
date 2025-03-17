using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Account.User
{
    public class UserRepo(Context ctx) : IUserRepo
    {
        private readonly Context _ctx = ctx;
        #region  SignUp 
        public async Task<RepoBase> ValidateToken(string data)
        {
            RepoBase _Result = new();
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
                    _Result.Records = Query;
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
        public async Task<RepoBase> GetUserById(string Id)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await _ctx.Users
                      .Select(s => new UserDto()
                      {
                          Id = s.Id,
                          Name = s.Name,
                          Email = s.Email,
                          BirthDate = s.BirthDate,
                          MaratialStatus = s.MaratialStatus,
                          Gender = s.Gender,
                          PhotoPath = s.PhotoPath,
                          PhoneNumber = s.PhoneNumber,
                          Fk_AdressId = s.Fk_AdressId,
                          Address = new AddressDto()
                          {
                              AddressId = s.Address.AddressId,
                              At = s.Address.At,
                              City = s.Address.City,
                              PinCode = s.Address.PinCode,
                              Post = s.Address.Post,
                              Fk_DistId = s.Address.Fk_DistId,
                              Fk_StateId = s.Address.Fk_StateId,
                              Fk_CountryId = s.Address.Fk_CountryId,
                          },
                      }).SingleOrDefaultAsync(s => s.Id == Id);
                if (Query != null)
                {
                    _Result.Records = Query;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
    }
}
