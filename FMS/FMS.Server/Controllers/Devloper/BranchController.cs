using FMS.Db.Entity;
using FMS.Model.Devloper;
using FMS.Svcs.DevloperSetting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Devloper
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper")]
    public class BranchController(IDevloperSettingSvcs devloperSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IDevloperSettingSvcs _devloperSvcs = devloperSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> CreateBranch([FromBody] BranchModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _devloperSvcs.CreateBranch(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateBranch), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBranch()
        {
            var result = await _devloperSvcs.GetAllBranch();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPut, Route("{id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateBranch([FromRoute] Guid id, [FromBody] BranchModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _devloperSvcs.UpdateBranch(id, model, user);
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
        [HttpDelete, Route("{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveBranch([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _devloperSvcs.RemoveBranch(id, user);
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
        public async Task<IActionResult> GetAllRemovedBranch()
        {
            var result = await _devloperSvcs.GetRemovedBranches();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Route("{id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverBranch([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _devloperSvcs.RecoverBranch(id, user);
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
        [HttpPatch, Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverAllBranch([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _devloperSvcs.RecoverAllBranch(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete, Route("{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteBranch([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _devloperSvcs.DeleteBranch(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(policy: "Delete")]
        public  async Task<IActionResult> DeleteAllBranch([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _devloperSvcs.DeleteAllBranch(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
    }
}
