using FMS.Db;
using FMS.Model.Admin;
using Microsoft.EntityFrameworkCore;
namespace FMS.Repo.Account.Authentication
{
    public class AuthenticationRepo(
        Context ctx
    ) : IAuthentication
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        #endregion
        #region  SignUp Token
        public async Task<Result<RegisterTokenViewModel>> ValidateToken(string data)
        {
            Result<RegisterTokenViewModel> _Result = new();
            try
            {
                _Result.IsSucess = false;
                var Query = await (from rt in _ctx.RegisterTokens
                                   join au in _ctx.AppUsers on rt.TokenId equals au.FkTokenId into auGroup
                                   from au in auGroup.DefaultIfEmpty()
                                   where rt.TokenValue == data && au == null
                                   select new RegisterTokenViewModel
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
        #endregion
    }
}
