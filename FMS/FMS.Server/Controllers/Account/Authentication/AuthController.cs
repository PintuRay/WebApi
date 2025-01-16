using FMS.Db.Entity;
using FMS.Model.Account.Authentication;
using FMS.Svcs.Account.Authentication;
using FMS.Svcs.SMS;
using FMS.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace FMS.Server.Controllers.Account.Authentication
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
        #region SignUp 
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> ValidateToken([FromQuery] string Token)
        {
            if (!string.IsNullOrEmpty(Token))
            {
                string pattern = @"^\d{3}-\d{3}-\d{4}$";
                if (Regex.IsMatch(Token, pattern))
                {
                    var result = await _authenticationSvcs.ValidateToken(Token);
                    return result.ResponseCode switch
                    {
                        200 => StatusCode(200, result),
                        404 => StatusCode(404, result),
                        _ => BadRequest(result)
                    };
                }
            }
            return BadRequest("Invalid Token");
        }
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse([FromQuery] string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                string emailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (Regex.IsMatch(email, emailRegex))
                {
                    var result = await _authenticationSvcs.IsEmailInUse(email);
                    return result.ResponseCode switch
                    {
                        200 => StatusCode(200, result),
                        404 => StatusCode(404, result),
                        _ => BadRequest(result)
                    };
                }
            }
            return BadRequest("Invalid email");
        }
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> IsPhoneNumberInUse([FromQuery] string phoneNumber)
        {
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                string phoneNoRegex = @"^\d{10}$";
                if (Regex.IsMatch(phoneNumber, phoneNoRegex))
                {
                    var result = await _authenticationSvcs.IsPhoneNumberInUse(phoneNumber);
                    return result.ResponseCode switch
                    {
                        200 => StatusCode(200, result),
                        404 => StatusCode(404, result),
                        _ => BadRequest(result)
                    };
                }
            }
            return BadRequest("Invalid data");
        }
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> IsUserNameExist([FromQuery] string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {

                var result = await _authenticationSvcs.IsUserNameExist(userName);
                return result.ResponseCode switch
                {
                    200 => StatusCode(200, result),
                    404 => StatusCode(404, result),
                    _ => BadRequest(result)
                };
            }
            return BadRequest("Invalid data");
        }
        [HttpPost, Consumes("multipart/form-data"), AllowAnonymous]
        public async Task<IActionResult> SignUp([FromForm] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ProfilePhoto != null)
                {
                    string StorageLocation = "images/ProfilePhoto/";
                    string path = PictureStorage.UploadPhoto(model.ProfilePhoto, StorageLocation);
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, path);
                    await model.ProfilePhoto.CopyToAsync(new FileStream(uploadsFolder, FileMode.Create));
                    if (path != null)
                    {
                        model.PhotoPath = path;
                    }
                }
                var result = await _authenticationSvcs.SignUp(model);
                return result.ResponseCode switch
                {
                    201 => StatusCode(201, result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
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
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
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
