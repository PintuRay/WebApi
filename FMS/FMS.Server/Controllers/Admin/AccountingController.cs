using FMS.Db.Entity;
using FMS.Svcs.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Admin
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper,Admin")]
    public class AccountingController(IAdminSvcs adminSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IAdminSvcs _adminSvcs = adminSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Group
        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var result = await _adminSvcs.GetGroups();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        #endregion
        #region SubGroup
        #region Crud
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> CreateSubGroup([FromBody] LedgerSubGroupModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.CreateSubGroup(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateSubGroup), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetSubGroups(Guid GroupId, Guid BranchId)
        {
            var result = await _adminSvcs.GetSubGroups(GroupId, BranchId);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPut, Route("{id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateSubGroup([FromRoute] Guid id, [FromBody] LedgerSubGroupModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _adminSvcs.UpdateSubGroup(id, model, user);
                    return result.ResponseCode == 200 ? Ok(result): BadRequest(result);
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
        [HttpDelete, Route("SubGroupd/{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveSubGroup([FromRoute] Guid id, [FromRoute] Guid BranchId)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.RemoveSubGroup(id, BranchId, user);
                return result.ResponseCode == 200 ? Ok(result) :  BadRequest(result);
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Recover
        [HttpGet]
        public async Task<IActionResult> GetRemovedSubGroup(Guid BranchId)
        {
            var result = await _adminSvcs.GetRemovedSubGroups(BranchId);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Route("{id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverSubGroup([FromRoute] Guid id, [FromRoute] Guid BranchId)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _adminSvcs.RecoverSubGroup(id, BranchId, user);
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
        public async Task<IActionResult> RecoverAllSubGroup([FromBody] List<string> Ids, [FromRoute] Guid BranchId)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _adminSvcs.RecoverAllSubGroup(Ids, BranchId, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete, Route("{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteSubGroup([FromRoute] Guid id, [FromRoute] Guid BranchId)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.DeleteSubGroup(id, BranchId, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllSubGroup([FromBody] List<string> Ids, [FromRoute] Guid BranchId)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _adminSvcs.DeleteAllSubGroup(Ids, BranchId, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
        #endregion
    }
}
