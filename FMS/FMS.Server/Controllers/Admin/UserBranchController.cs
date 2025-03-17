using FMS.Db.Entity;
using FMS.Model;
using FMS.Svcs.Admin;
using FMS.Svcs.Admin.UserBranch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FMS.Server.Controllers.Admin
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper,Admin")]
    public class UserBranchController(IUserBranchSvcs userBranchSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IUserBranchSvcs _userBranchSvcs = userBranchSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationParams pagination)
        {

            var result = await _userBranchSvcs.GetUserBranches(pagination);
            return result.ResponseCode switch
            {
                404 => StatusCode(404, result),
                200 => StatusCode(200, result),
                _ => BadRequest(result)
            };
        }
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> Create([FromBody] UserBranchModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _userBranchSvcs.CreateUserBranch(model, user);
                return result.ResponseCode switch
                {
                    201 => StatusCode(201, result),
                    302 => StatusCode(302, result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPatch, Authorize(policy: "Update")]
        public async Task<IActionResult> Update([FromBody] UserBranchUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _userBranchSvcs.UpdateUserBranch(model, user);
                return result.ResponseCode switch
                {
                    404 => StatusCode(404, result),
                    200 => StatusCode(200, result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPut("{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _userBranchSvcs.RemoveUserBranch(id, user);
                return result.ResponseCode switch
                {
                    404 => StatusCode(404, result),
                    200 => StatusCode(200, result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Recover
        [HttpGet]
        public async Task<IActionResult> GetRemoved(PaginationParams pagination)
        {
            var result = await _userBranchSvcs.GetRemovedUserBranches(pagination);
            return result.ResponseCode switch
            {
                404 => StatusCode(404, result),
                200 => StatusCode(200, result),
                _ => BadRequest(result)
            };
        }
        [HttpPut("{id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> Recover([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
              
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _userBranchSvcs.RecoverUserBranch(id, user);
                    return result.ResponseCode switch
                    {
                        404 => StatusCode(404, result),
                        302 => StatusCode(302, result),
                        200 => StatusCode(200, result),
                        _ => BadRequest(result)
                    };
            }
            else
            {
                return BadRequest("Plz Provide Valid Id");
            }
        }
        [HttpDelete("{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _userBranchSvcs.DeleteUserBranch(id, user);
                return result.ResponseCode switch
                {
                    404 => StatusCode(404, result),
                    200 => StatusCode(200, result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
    }
}
