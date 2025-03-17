using FMS.Db.Entity;
using FMS.Model.Account.Authentication;
using FMS.Svcs.Account.Authentication;
using FMS.Svcs.Account.User;
using FMS.Svcs.SMS;
using FMS.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace FMS.Server.Controllers.Account
{
    [ApiController, Route("[controller]/[action]")]
    public class AuthController(
        IAuthenticationSvcs authenticationSvcs,
        IWebHostEnvironment hostingEnvironment,
        UserManager<AppUser> userManager,
        ISmsSvcs smsSvcs) : ControllerBase
    {
        #region Dependancy
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IWebHostEnvironment _hostingEnvironment = hostingEnvironment;
        private readonly IAuthenticationSvcs _authenticationSvcs = authenticationSvcs;
        private readonly ISmsSvcs _smsSvcs = smsSvcs;
        #endregion
        #region Login
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationSvcs.SignIn(signInModel);
                return result.ResponseCode == 200 || result.ResponseCode == 405 ? Ok(result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> SignInWithOTP([FromBody] SignIn2faModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationSvcs.SignInWithOTP(model);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            return BadRequest();
        }
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> ReSendTwoFactorToken([FromQuery] string mail)
        {
            if (!string.IsNullOrEmpty(mail))
            {
                var result = await _authenticationSvcs.ReSendTwoFactorToken(mail);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            return BadRequest();
        }
        #endregion
        #region 2FA
        [HttpGet, Authorize]
        public async Task<IActionResult> SendTwoFactorToken([FromQuery] string uid)
        {
            if (!string.IsNullOrEmpty(uid))
            {
                var result = await _authenticationSvcs.SendTwoFactorToken(uid);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            return BadRequest("invaild UserId");
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> VerifyTwoFactorToken([FromBody] SignIn2faModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationSvcs.VerifyTwoFactorToken(model);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            return BadRequest("invaild OTP");
        }
        #endregion
        #region ThiredParty SignIn
        #endregion
        #region Email 
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> VerifyConfirmEmail([FromQuery] string uid, [FromQuery] string token)
        {
            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
            {
                var result = await _authenticationSvcs.VerifyConfirmEmail(uid, token);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            return BadRequest();
        }
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> ResendConfirmEmail([FromQuery] string email, [FromQuery] string routeUrl)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var result = await _authenticationSvcs.ResendConfirmEmail(email, routeUrl);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            return BadRequest();
        }
        #endregion
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
        #region Forgot, Reset && Change Password
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromQuery] string mail, [FromQuery] string routeUrl)
        {
            if (!string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(routeUrl))
            {
                var result = await _authenticationSvcs.ForgotPassword(mail, routeUrl);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            return BadRequest();
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationSvcs.ResetPassword(model);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
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
        #region LogOut
        [HttpGet, Authorize]
        public IActionResult LogOut()
        {
            var result = _authenticationSvcs.LogOut();
            return Ok(result);
        }
        #endregion
    }
}
