using FMS.Db.Entity;
using FMS.Repo.Admin.Token;
using FMS.Svcs.Email;

namespace FMS.Svcs.Admin.Token
{
    public class TokenSvcs(ITokenRepo tokenRepo, IEmailSvcs emailSvc) : ITokenSvcs
    {
        #region Dependancy
        private readonly ITokenRepo _tokenRepo = tokenRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Generate SignUp Token
        public async Task<SvcsBase> CreateToken(RegisterTokenModel Token, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _tokenRepo.CreateToken(Token, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Token Created",
                        ResponseCode = (int)ResponseCode.Status.Created,

                    },
                    false => new()
                    {
                        Message = "Token Already Used",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateToken", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
    }
}
