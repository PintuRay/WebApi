using FMS.Db.Entity;
using FMS.Model.Account.Authentication;
using FMS.Svcs.Account.Authentication;
using FMS.Svcs.SMS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace FMS.Server.Controllers.Account.Authentication
{
    [ApiController, Route("[controller]/[action]")]
    public class AuthController(
        IAuthenticationSvcs authenticationSvcs,
        UserManager<AppUser> userManager,
        ISmsSvcs smsSvcs) : ControllerBase
    {
        #region Dependancy
        private readonly UserManager<AppUser> _userManager = userManager;
        private readonly IAuthenticationSvcs _authenticationSvcs = authenticationSvcs;
        private readonly ISmsSvcs _smsSvcs = smsSvcs;
        #endregion
        #region SignUp 
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> ValidateToken([FromQuery] string Token)
        {
            string pattern = @"^\d{3}-\d{3}-\d{4}$";
            if (Regex.IsMatch(Token, pattern))
            {
                var result = await _authenticationSvcs.ValidateToken(Token);
                return result.ResponseCode == 200 ? Ok(result) : result.ResponseCode == 404 ? NotFound(result) : BadRequest(result);
            }
            else
            {
                return BadRequest("Invalid Token Format : Correct format : xxx-xxx-xxxx");
            }
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] UserModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationSvcs.SignUp(model);
                return result.ResponseCode == 201 ? Created(nameof(SignUp), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse([FromQuery] string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var result = await _authenticationSvcs.IsEmailInUse(email);
                return Ok(result);
            }
            return BadRequest();
        }
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
                return result.ResponseCode == 200 ? Ok(result) : result.ResponseCode == 404 ? NotFound(result) : BadRequest(result);
            }
            return BadRequest();
        }
        #endregion
        #region Login
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
        #endregion
        #region 2FA
        [HttpGet, Authorize]
        public async Task<IActionResult> SendTwoFactorToken()
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _authenticationSvcs.SendTwoFactorToken(user);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpGet, Authorize]
        public async Task<IActionResult> VerifyTwoFactorToken([FromQuery] string Token)
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
            if (ModelState.IsValid)
            {
                var result = await _authenticationSvcs.SignInWithOTP(model);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            return BadRequest();
        }
        #endregion
        #region ThiredParty SignIn
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
