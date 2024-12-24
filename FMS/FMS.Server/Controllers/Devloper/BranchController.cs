using FMS.Db.Entity;
using FMS.Model;
using FMS.Svcs.Devloper.Branch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Devloper
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper")]
    public class BranchController(IBranchSvcs branchSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IBranchSvcs _branchSvcs = branchSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        [HttpGet]
        public async Task<IActionResult> GetAllBranch([FromBody] PaginationParams pagination)
        {
            var result = await _branchSvcs.GetAllBranch(pagination);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> CreateBranch([FromBody] BranchModel data)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchSvcs.CreateBranch(data, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateBranch), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPut, Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateBranch([FromQuery] Guid id, [FromBody] BranchModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _branchSvcs.UpdateBranch(id, model, user);
                    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
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
        [HttpDelete, Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveBranch([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchSvcs.RemoveBranch(id, user);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Recover
        [HttpGet]
        public async Task<IActionResult> GetAllRemovedBranch([FromBody] PaginationParams pagination)
        {
            var result = await _branchSvcs.GetRemovedBranches(pagination);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Route("{id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverBranch([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _branchSvcs.RecoverBranch(id, user);
                    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
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
        [HttpPatch, Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverAllBranch([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _branchSvcs.RecoverAllBranch(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpDelete, Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteBranch([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchSvcs.DeleteBranch(id, user);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllBranch([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _branchSvcs.DeleteAllBranch(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        #endregion
    }
}
