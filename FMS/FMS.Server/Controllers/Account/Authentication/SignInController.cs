using FMS.Db.Entity;
using FMS.Model.Account.Authentication;
using FMS.Repo;
using FMS.Svcs.Account.Authentication;
using FMS.Svcs.SMS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Twilio.Jwt.AccessToken;
using Twilio.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FMS.Server.Controllers.Account.Authentication
{
    [ApiController, Route("[controller]/[action]")]
    public class SignInController(
        IAuthenticationSvcs authenticationSvcs,
        UserManager<AppUser> userManager,
        ISmsSvcs smsSvcs) : ControllerBase
    {
        #region Dependancy
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IAuthenticationSvcs _authenticationSvcs = authenticationSvcs;
        private readonly ISmsSvcs _smsSvcs = smsSvcs;
        #endregion
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationSvcs.SignIn(signInModel);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        #region SMS
        [HttpGet, Authorize]
        public async Task<IActionResult> GetUserPhoneNumber()
        {
            var user = await _userManager.GetUserAsync(User);
            var PhoneNumber = user.PhoneNumber;
            return Ok(new { phoneNo = PhoneNumber });
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> SendConformationSms(string PhoneNo)
        {
            if (PhoneNo != null)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _authenticationSvcs.SendConformationSms(user, PhoneNo);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            return BadRequest();
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> VerifyPhoneNumber(string Token, string PhoneNo)
        {
            if (Token != null)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _authenticationSvcs.VerifyPhoneNumber(user, Token, PhoneNo);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            return BadRequest();
        }
        #endregion
        #region 2FA
        [HttpGet, Authorize]
        public async Task<IActionResult> SendTwoFactorToken()
        {
            var user = await _userManager.GetUserAsync(User);
            if (!user.PhoneNumberConfirmed)
            {
                var result = await _authenticationSvcs.SendTwoFactorToken(user);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            return BadRequest("Phone Number Not Conformed Yet");
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> VerifyTwoFactorToken(string Token)
        {
            if (!string.IsNullOrEmpty(Token))
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _authenticationSvcs.VerifyTwoFactorToken(Token, user);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            return BadRequest("invaild Token");
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> SignInWithOTP([FromBody] SignIn2faModel model)
        {
            if(ModelState.IsValid) {
                var result = await _authenticationSvcs.SignInWithOTP(model);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
           return BadRequest();
        }
        #endregion
        #region ThiredParty SignIn
        #endregion
        #region Forgot, Reset && Change Password
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromQuery] string mail)
        {
            if (!string.IsNullOrEmpty(mail))
            {
                var result = await _authenticationSvcs.ForgotPassword(mail);
                return result.ResponseCode == 200 ? Ok(result) : result.ResponseCode == 404 ? NotFound(result) : BadRequest(result);
            }
            return BadRequest();
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromQuery] string uid, [FromQuery] string token, [FromBody] ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
                {
                    var result = await _authenticationSvcs.ResetPassword(uid, token, model);
                    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _authenticationSvcs.ChangePassword(user, model);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        #endregion
    }
}
