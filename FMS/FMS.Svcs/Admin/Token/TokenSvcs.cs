using FMS.Db.Entity;
using FMS.Repo.Admin.Token;
using FMS.Svcs.Email;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FMS.Svcs.Admin.Token
{
    public class TokenSvcs(ITokenRepo tokenRepo, RegisterTokenValidator registerTokenValidator, IEmailSvcs emailSvc) : ITokenSvcs
    {
        #region Dependancy
        private readonly ITokenRepo _tokenRepo = tokenRepo;
        private readonly RegisterTokenValidator _registerTokenValidator = registerTokenValidator;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Generate SignUp Token
        public async Task<SvcsBase> CreateToken(RegisterTokenModel Token, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationResult = await _registerTokenValidator.ValidateAsync(Token);
                if (validationResult.IsValid)
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
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                        },
                    };
                }
                else
                {
                    Obj = new()
                    {
                        Data = validationResult.Errors.ToArray(),
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "CreateToken", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
    }
}
