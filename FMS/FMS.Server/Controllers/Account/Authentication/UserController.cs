using FMS.Model.Account.Authentication;
using FMS.Svcs.Account.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Account.Authentication
{
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Admin,Devloper")]

    public class UserController(IAuthenticationSvcs authenticationSvcs) : ControllerBase
    {
        private readonly IAuthenticationSvcs _authenticationSvcs = authenticationSvcs;
        #region User
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _authenticationSvcs.GetUsers();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpGet, Route("email/{email}")]
        public async Task<IActionResult> GetUserByMail([FromRoute] string email)
        {
            if (email != null)
            {
                var result = await _authenticationSvcs.GetUserByMail(email);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Plz Provide Valid Mail");
            }
        }
        [HttpGet, Route("{Id}")]
        public async Task<IActionResult> GetUserById([FromRoute] string Id)
        {
            if (Id != null)
            {
                var result = await _authenticationSvcs.GetUserById(Id);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Plz Provide Valid Id");
            }
        }
        [HttpPatch, Route("{Id}"), Authorize(Policy = "Update")]
        public async Task<IActionResult> UpdateUser([FromRoute] string Id, [FromBody] UserModel User)
        {
            if (Id != null)
            {
                if (ModelState.IsValid)
                {
                    var result = await _authenticationSvcs.UpdateUser(Id, User);
                    return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
                }
                else
                {
                    var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                    return BadRequest(errors);
                }
            }
            else
            {
                return BadRequest("Plz Provide Valid Id");
            }
        }
        [HttpDelete, Route("{Id}"), Authorize(Policy = "Delete")]
        public async Task<IActionResult> DeleteUser([FromRoute] string Id)
        {
            if (Id != null)
            {
                var result = await _authenticationSvcs.DeletUser(Id);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
    }
}
