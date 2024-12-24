using FMS.Db.Entity;
using FMS.Svcs.Admin;
using FMS.Svcs.Admin.UserBranch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> CreateUserBranch([FromBody] UserBranchModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _userBranchSvcs.CreateUserBranch(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateUserBranch), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetUserBranches()
        {
            var result = await _userBranchSvcs.GetUserBranches();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPut, Route("{id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateUserBranch([FromRoute] Guid id, [FromBody] UserBranchModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _userBranchSvcs.UpdateUserBranch(id, model, user);
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
        [HttpDelete, Route("BranchAllocationid/{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveUserBranch([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _userBranchSvcs.RemoveUserBranch(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Recover
        [HttpGet]
        public async Task<IActionResult> GetRemovedUserBranches()
        {
            var result = await _userBranchSvcs.GetRemovedUserBranches();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Route("{id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverUserBranch([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _userBranchSvcs.RecoverUserBranch(id, user);
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
        [HttpPost, Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverAllUserBranches([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _userBranchSvcs.RecoverAllUserBranches(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete, Route("{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteUserBranch([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _userBranchSvcs.DeleteUserBranch(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllUserBranches([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _userBranchSvcs.DeleteAllUserBranches(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
    }
}
