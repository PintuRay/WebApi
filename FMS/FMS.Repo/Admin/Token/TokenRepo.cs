using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Admin.Token
{
    public class TokenRepo(Context ctx, IMapper mapper, IRedisCache cache) : ITokenRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;
        private readonly IRedisCache _cache = cache;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(3);
        #endregion
        #region Generate SignUp Token
        //public async Task<RepoBase> CreateToken(RegisterTokenModel model, AppUser user)
        //{
        //    RepoBase _Result = new();
        //    try
        //    {
        //        _Result.IsSucess = false;
        //        var isExistToken = await (from s in _ctx.RegisterTokens where s.TokenValue == model.TokenValue select s).SingleOrDefaultAsync();
        //        if (isExistToken == null)
        //        {
        //            var regToken = _mapper.Map<RegisterToken>(model);
        //            await _ctx.RegisterTokens.AddAsync(regToken);
        //            int Count = await _ctx.SaveChangesAsync();
        //            _Result.Count = Count.ToString();
        //            if (Count > 0)
        //            {
        //                _Result.Id = regToken.TokenId.ToString();
        //                _Result.IsSucess = true;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return _Result;
        //}
        #endregion
    }
}
