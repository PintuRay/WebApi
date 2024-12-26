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
        //[HttpGet]
        //public async Task<IActionResult> Get([FromBody] PaginationParams pagination)
        //{
        //    var result = await _branchSvcs.GetAllBranch(pagination);
        //    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //}
        //[HttpPost, Authorize(policy: "Create")]
        //public async Task<IActionResult> Create([FromBody] BranchModel data)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var result = await _branchSvcs.CreateBranch(data, user);
        //        return result.ResponseCode == 201 ? Created(nameof(Create), result) : BadRequest(result);
        //    }
        //    else
        //    {
        //        var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
        //        return BadRequest(errors);
        //    }
        //}
        //[HttpPut("{id}"), Authorize(policy: "Update")]
        //public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] BranchModel model)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var user = await _userManager.GetUserAsync(User);
        //            var result = await _branchSvcs.UpdateBranch(id, model, user);
        //            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //        }
        //        else
        //        {
        //            var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
        //            return BadRequest(errors);
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("Plz Provide Valid Id");
        //    }
        //}
        //[HttpDelete("{id}"), Authorize(policy: "Delete")]
        //public async Task<IActionResult> Remove([FromRoute] Guid id)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var result = await _branchSvcs.RemoveBranch(id, user);
        //        return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //    }
        //    else
        //    {
        //        return BadRequest("Invalid Id");
        //    }
        //}
        #endregion
        #region Recover
        //[HttpGet]
        //public async Task<IActionResult> GetRemoved([FromBody] PaginationParams pagination)
        //{
        //    var result = await _branchSvcs.GetRemovedBranches(pagination);
        //    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //}
        //[HttpPatch("{id}"), Authorize(policy: "Update")]
        //public async Task<IActionResult> Recover([FromRoute] Guid id)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var user = await _userManager.GetUserAsync(User);
        //            var result = await _branchSvcs.RecoverBranch(id, user);
        //            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //        }
        //        else
        //        {
        //            var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
        //            return BadRequest(errors);
        //        }
        //    }
        //    else
        //    {
        //        return BadRequest("Plz Provide Valid Id");
        //    }
        //}
        //[HttpPatch, Authorize(policy: "Update")]
        //public async Task<IActionResult> RecoverAll([FromBody] List<string> Ids)
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    var result = await _branchSvcs.RecoverAllBranch(Ids, user);
        //    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //}
        //[HttpDelete("{id}"), Authorize(policy: "Delete")]
        //public async Task<IActionResult> Delete([FromRoute] Guid id)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var result = await _branchSvcs.DeleteBranch(id, user);
        //        return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //    }
        //    else
        //    {
        //        return BadRequest("Invalid Id");
        //    }
        //}
        //[HttpPost, Authorize(policy: "Delete")]
        //public async Task<IActionResult> DeleteAll([FromBody] List<string> Ids)
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    var result = await _branchSvcs.DeleteAllBranch(Ids, user);
        //    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //}
        #endregion
    }
}
