using FMS.Db.Entity;
using FMS.Svcs.Admin.Accounting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Admin
{
    [Produces("application/json")]
    [ApiController, Route("Accounting"), Authorize(Roles = "Devloper,Admin")]
    public class AccountingController(IAccountingSvcs accountingSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IAccountingSvcs _accountingSvcs = accountingSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Group
        //[HttpGet, Route("Group/Get")]
        //public async Task<IActionResult> GetGroups()
        //{
        //    var result = await _accountingSvcs.GetGroups();
        //    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //}
        #endregion
        #region SubGroup
        #region Crud
        //[HttpPost, Route("SubGroup/Create"), Authorize(policy: "Create")]
        //public async Task<IActionResult> CreateSubGroup([FromBody] LedgerSubGroupModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var result = await _accountingSvcs.CreateSubGroup(model, user);
        //        return result.ResponseCode == 201 ? Created(nameof(CreateSubGroup), result) : BadRequest(result);
        //    }
        //    else
        //    {
        //        var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
        //        return BadRequest(errors);
        //    }
        //}
        //[HttpGet,Route("SubGroup/Get")]
        //public async Task<IActionResult> GetSubGroups([FromQuery]Guid GroupId, [FromQuery] Guid BranchId)
        //{
        //    var result = await _accountingSvcs.GetSubGroups(GroupId, BranchId);
        //    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //}
        //[HttpPut, Route("SubGroup/Update/{id}"), Authorize(policy: "Update")]
        //public async Task<IActionResult> UpdateSubGroup([FromRoute] Guid id, [FromBody] LedgerSubGroupModel model)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var user = await _userManager.GetUserAsync(User);
        //            var result = await _accountingSvcs.UpdateSubGroup(id, model, user);
        //            return result.ResponseCode == 200 ? Ok(result): BadRequest(result);
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
        //[HttpDelete, Route("SubGroup/Remove"), Authorize(policy: "Delete")]
        //public async Task<IActionResult> RemoveSubGroup([FromQuery] Guid id, [FromQuery] Guid BranchId)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var result = await _accountingSvcs.RemoveSubGroup(id, BranchId, user);
        //        return result.ResponseCode == 200 ? Ok(result) :  BadRequest(result);
        //    }
        //    else
        //    {
        //        return BadRequest("Invalid Id");
        //    }
        //}
        #endregion
        #region Recover
        //[HttpGet, Route("SubGroup/GetRemoved/{BranchId}")]
        //public async Task<IActionResult> GetRemovedSubGroup([FromRoute] Guid BranchId)
        //{
        //    var result = await _accountingSvcs.GetRemovedSubGroups(BranchId);
        //    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //}
        //[HttpPatch, Route("SubGroup/Recover"), Authorize(policy: "Update")]
        //public async Task<IActionResult> RecoverSubGroup([FromQuery] Guid Id, [FromQuery] Guid BranchId)
        //{
        //    if (Id != Guid.Empty)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var user = await _userManager.GetUserAsync(User);
        //            var result = await _accountingSvcs.RecoverSubGroup(Id, BranchId, user);
        //            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
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
        //[HttpPost, Route("SubGroup/RecoverAll"), Authorize(policy: "Update")]
        //public async Task<IActionResult> RecoverAllSubGroup([FromBody] List<string> Ids, [FromQuery] Guid BranchId)
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    var result = await _accountingSvcs.RecoverAllSubGroup(Ids, BranchId, user);
        //    return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        //}
        //[HttpDelete, Route("SubGroup/Delete"), Authorize(policy: "Delete")]
        //public async Task<IActionResult> DeleteSubGroup([FromQuery] Guid Id, [FromQuery] Guid BranchId)
        //{
        //    if (Id != Guid.Empty)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var result = await _accountingSvcs.DeleteSubGroup(Id, BranchId, user);
        //        return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        //    }
        //    else
        //    {
        //        return BadRequest("Invalid Id");
        //    }
        //}
        //[HttpPost, Route("SubGroup/DeleteAll"), Authorize(policy: "Delete")]
        //public async Task<IActionResult> DeleteAllSubGroup([FromBody] List<string> Ids, [FromQuery] Guid BranchId)
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    var result = await _accountingSvcs.DeleteAllSubGroup(Ids, BranchId, user);
        //    return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        //}
        #endregion
        #endregion
        #region Ledgers
        #region Crud
        //[HttpPost, Route("Ledger/Create"),Authorize(policy: "Create")]
        //public async Task<IActionResult> CreateLedger([FromBody] LedgerModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var result = await _accountingSvcs.CreateLedger(model, user);
        //        return result.ResponseCode == 201 ? Created(nameof(CreateLedger), result) : BadRequest(result);
        //    }
        //    else
        //    {
        //        var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
        //        return BadRequest(errors);
        //    }
        //}
        //[HttpGet, Route("Ledger/Get")]
        //public async Task<IActionResult> GetLedgers()
        //{
        //    var result = await _accountingSvcs.GetLedgers();
        //    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //}
        //[HttpPut, Route("Ledger/Update/{id}"),Authorize(policy: "Update")]
        //public async Task<IActionResult> UpdateLedger([FromRoute] Guid id, [FromBody] LedgerModel model)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var user = await _userManager.GetUserAsync(User);
        //            var result = await _accountingSvcs.UpdateLedger(id, model, user);
        //            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
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
        //[HttpDelete, Route("Ledger/Remove/{id}"), Authorize(policy: "Delete")]
        //public async Task<IActionResult> RemoveLedger([FromRoute] Guid id)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var result = await _accountingSvcs.RemoveLedger(id, user);
        //        return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        //    }
        //    else
        //    {
        //        return BadRequest("Invalid Id");
        //    }
        //}
        #endregion
        #region Recover
        //[HttpGet,Route("Ledger/GetRemoved")]
        //public async Task<IActionResult> GetRemovedLedgers()
        //{
        //    var result = await _accountingSvcs.GetRemovedLedgers();
        //    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //}
        //[HttpPatch, Route("Ledger/Recover/{id}"), Authorize(policy: "Update")]
        //public async Task<IActionResult> RecoverLedger([FromRoute] Guid id)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var user = await _userManager.GetUserAsync(User);
        //            var result = await _accountingSvcs.RecoverLedger(id, user);
        //            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
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
        //[HttpPost, Route("Ledger/RecoverAll"), Authorize(policy: "Update")]
        //public async Task<IActionResult> RecoverAllLedger([FromBody] List<string> Ids)
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    var result = await _accountingSvcs.RecoverAllLedger(Ids, user);
        //    return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        //}
        //[HttpDelete, Route("Ledger/Delete/{id}"), Authorize(policy: "Delete")]
        //public async Task<IActionResult> DeleteLedger([FromRoute] Guid id)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var result = await _accountingSvcs.DeleteLedger(id, user);
        //        return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        //    }
        //    else
        //    {
        //        return BadRequest("Invalid Id");
        //    }
        //}
        //[HttpPost, Route("Ledger/DeleteAll"), Authorize(policy: "Delete")]
        //public async Task<IActionResult> DeleteAllLedger([FromBody] List<string> Ids)
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    var result = await _accountingSvcs.DeleteAllLedger(Ids, user);
        //    return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        //}
        #endregion
        #endregion
    }
}
