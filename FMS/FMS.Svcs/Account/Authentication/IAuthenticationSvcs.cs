using FMS.Db.Entity;
using FMS.Model;
using FMS.Model.Account.Authentication;
using System.Drawing;
using Twilio.Jwt.AccessToken;

namespace FMS.Svcs.Account.Authentication
{
    public interface IAuthenticationSvcs
    {
        #region SignUp 
        Task<Base> ValidateToken(string Token);
        Task<Base> IsEmailInUse(string email);
        Task<Base> SignUp(UserModel data);
        #endregion
        #region SignIn 
        Task<Base> SignIn(SignInModel data);
        #endregion
        #region ThiredParty SignIn
        #endregion
        #region Forgot, Reset && Change Password
        Task<Base> ForgotPassword(string mail, string routeUrl);
        Task<Base> ResetPassword(string uid, string token, ResetPasswordModel model);
        Task<Base> ChangePassword(AppUser user, ChangePasswordModel model);
        #endregion
        #region Email 
        Task<Base> VerifyConfirmEmail(string uid, string token);
        Task<Base> ResendConfirmEmail(string mail, string RouteUrl); 
        #endregion
        #region SMS
        Task<Base> SendConformationSms(AppUser User, string PhoneNo);
        Task<Base> VerifyPhoneNumber(AppUser User, string Token, string PhoneNo);
        #endregion
        #region 2FA
         Task<Base> SendTwoFactorToken(AppUser user);
        Task<Base> VerifyTwoFactorToken(string Token, AppUser user);
        Task<Base> SignInWithOTP(SignIn2faModel model);
        #endregion  
    }
}
