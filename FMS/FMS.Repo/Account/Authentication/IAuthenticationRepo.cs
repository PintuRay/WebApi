﻿using FMS.Db.Entity;
namespace FMS.Repo.Account.Authentication
{
    public interface IAuthenticationRepo
    {
        #region  SignUp Token
        Task<Result<RegisterToken>> ValidateToken(string data);
        Task<bool> IsPhoneNumberInUse(string data);
        #endregion
        #region Address
        Task<RepoBase> CreateUserAdress(AddressModel data , AppUser user);
        #endregion
    }
}
