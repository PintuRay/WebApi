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
    }
}
