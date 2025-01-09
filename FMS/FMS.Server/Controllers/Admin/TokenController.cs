using FMS.Db.Entity;
using FMS.Svcs.Admin;
using FMS.Svcs.Admin.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Admin
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper,Admin")]
    public class TokenController(ITokenSvcs tokenSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly ITokenSvcs _tokenSvcs = tokenSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> GenerateRegistationToken([FromBody] RegisterTokenModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _tokenSvcs.CreateToken(model, user);
                return result.ResponseCode == 201 ? Created(nameof(GenerateRegistationToken), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
    }
}
