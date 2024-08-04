using FMS.Model.Account.Autherization;
using FMS.Svcs.Account.Autherization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Account.Autherization
{
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Admin,Devloper")]
    public class UserRoleClaimsController(IAutherizationSvcs autherizationSvcs) : ControllerBase
    {
        #region Dependancy
        private readonly IAutherizationSvcs _autherizationSvcs = autherizationSvcs;
        #endregion
        #region User-Role && User-Claims
        [HttpGet, Route("{RoleId}")]
        public async Task<IActionResult> GetUserInRoleWithClaims([FromRoute] string RoleId)
        {
            if (RoleId != null)
            {
                var result = await _autherizationSvcs.GetUserInRoleWithClaims(RoleId);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Plz Provide Valid Id");
            }
        }
        [HttpPatch, Authorize(Policy = "Update")]
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
