using FMS.Model.Account.Authentication;
using FMS.Model.Account.Autherization;
using FMS.Svcs.Account.Autherization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Account.Autherization
{
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Admin,Devloper")]
    public class UserController(IAutherizationSvcs autherizationSvcs) : ControllerBase
    {
        #region Dependancy
        private readonly IAutherizationSvcs _autherizationSvcs = autherizationSvcs;
        #endregion
        #region User
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _autherizationSvcs.GetUsers();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpGet, Route("email/{email}")]
        public async Task<IActionResult> GetUserByMail([FromRoute] string email)
        {
            if (email != null)
            {
                var result = await _autherizationSvcs.GetUserByMail(email);
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
                var result = await _autherizationSvcs.GetUserById(Id);
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
                    var result = await _autherizationSvcs.UpdateUser(Id, User);
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
                var result = await _autherizationSvcs.DeletUser(Id);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Role
        [HttpPost, Authorize(Policy = "Create")]
        public async Task<IActionResult> CreateRole([FromBody] RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _autherizationSvcs.CreateRole(model);
                return result.ResponseCode == 201 ? Created(nameof(CreateRole), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _autherizationSvcs.GetRoles();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpGet, Route("{Id}")]
        public async Task<IActionResult> GetRoleById([FromRoute] string Id)
        {
            if (Id != null)
            {
                var result = await _autherizationSvcs.GetRoleById(Id);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Plz Provide Valid Id");
            }
        }
        [HttpPatch, Route("{Id}"), Authorize(Policy = "Update")]
        public async Task<IActionResult> UpdateRole([FromRoute] string Id, [FromBody] RoleModel model)
        {
            if (Id != null)
            {
                if (ModelState.IsValid)
                {
                    var result = await _autherizationSvcs.UpdateRole(Id, model);
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
        public async Task<IActionResult> DeleteRole([FromRoute] string Id)
        {
            if (Id != null)
            {
                var result = await _autherizationSvcs.DeleteRole(Id);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region User-Role && User-Claims
        [HttpGet]
        public async Task<IActionResult> GetAllUserWithRolesAndClaims()
        {
            var result = await _autherizationSvcs.GetAllUserWithRolesAndClaims();
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpGet, Route("{UserId}")]
        public async Task<IActionResult> GetUserWithRolesAndClaims([FromRoute] string UserId)
        {
            if (UserId != null)
            {
                var result = await _autherizationSvcs.GetUserWithRolesAndClaims(UserId);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Plz Provide Valid Id");
            }
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateUserRoleAndClaims([FromBody] UserRoleClaimModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _autherizationSvcs.UpdateUserRoleAndClaims(model);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
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
