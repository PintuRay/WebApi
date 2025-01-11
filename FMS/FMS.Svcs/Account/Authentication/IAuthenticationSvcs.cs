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
        Task<SvcsBase> ValidateToken(string Token);
        Task<SvcsBase> IsEmailInUse(string email);
        Task<SvcsBase> IsPhoneNumberInUse(string phoneNumber);
        Task<SvcsBase> IsUserNameExist(string userName);
        Task<SvcsBase> SignUp(RegisterModel data);
        #endregion
        #region SignIn 
        Task<SvcsBase> SignIn(SignInModel data);
        #endregion
        #region ThiredParty SignIn
        #endregion
        #region Forgot, Reset && Change Password
        Task<SvcsBase> ForgotPassword(string mail, string routeUrl);
        Task<SvcsBase> ResetPassword(string uid, string token, ResetPasswordModel model);
        Task<SvcsBase> ChangePassword(AppUser user, ChangePasswordModel model);
        #endregion
        #region Email 
        Task<SvcsBase> VerifyConfirmEmail(string uid, string token);
        Task<SvcsBase> ResendConfirmEmail(string mail, string RouteUrl); 
        #endregion
        #region SMS
        Task<SvcsBase> SendConformationSms(AppUser User, string PhoneNo);
        Task<SvcsBase> VerifyPhoneNumber(AppUser User, string Token, string PhoneNo);
        #endregion
        #region 2FA
         Task<SvcsBase> SendTwoFactorToken(AppUser user);
        Task<SvcsBase> VerifyTwoFactorToken(string Token, AppUser user);
        Task<SvcsBase> SignInWithOTP(SignIn2faModel model);
        Task<SvcsBase> ReSendTwoFactorToken(string mail);
        #endregion
        #region Logout
        SvcsBase LogOut();
        #endregion
    }
}
