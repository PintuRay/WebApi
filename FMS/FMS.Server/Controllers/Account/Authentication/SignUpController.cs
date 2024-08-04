using FMS.Model.Account.Authentication;
using FMS.Svcs.Account.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace FMS.Server.Controllers.Account.Authentication
{
    [ApiController, Route("[controller]/[action]")]
    public class SignUpController(IAuthenticationSvcs authenticationSvcs) : ControllerBase
    {
        private readonly IAuthenticationSvcs _authenticationSvcs = authenticationSvcs;
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
        public async Task<IActionResult> IsEmailInUse(string email)
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
        public async Task<IActionResult> ResendConfirmEmail([FromQuery] string mail)
        {
            if (!string.IsNullOrEmpty(mail))
            {
                var result = await _authenticationSvcs.ResendConfirmEmail(mail);
                return result.ResponseCode == 200 ? Ok(result) : result.ResponseCode == 404 ? NotFound(result) : BadRequest(result);
            }
            return BadRequest();
        }
        #endregion
    }
}
