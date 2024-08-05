using FMS.Db.Entity;
using FMS.Model.Account;
using FMS.Model.Admin;
using FMS.Svcs.AdminSetting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace FMS.Server.Controllers.Admin
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper,Admin")]
    public class TokenController(IAdminSettingSvcs adminSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IAdminSettingSvcs _adminSvcs = adminSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> GenerateRegistationToken([FromBody] RegisterTokenModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _adminSvcs.CreateToken(model);
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
