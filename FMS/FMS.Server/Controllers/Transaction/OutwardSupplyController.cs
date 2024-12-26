using FMS.Db.Entity;
using FMS.Svcs.Transaction;
using FMS.Svcs.Transaction.OutwardSupply;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Transaction
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "User,Admin,Devloper")]
    public class OutwardSupplyController(IOutwardSupplySvcs outwardSupplySvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IOutwardSupplySvcs _outwardSupplySvcs = outwardSupplySvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        //[HttpPost, Authorize(policy: "Create")]
        //public async Task<IActionResult> Create([FromBody] OutwardSupplyOrderModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var result = await _outwardSupplySvcs.CreateOutwardSupplyTransaction(model, user);
        //        return result.ResponseCode == 201 ? Created(nameof(Create), result) : BadRequest(result);
        //    }
        //    else
        //    {
        //        var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
        //        return BadRequest(errors);
        //    }
        //}
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var result = await _outwardSupplySvcs.GetOutwardSupplyTransactions();
        //    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById([FromRoute] Guid Id)
        //{
        //    var result = await _outwardSupplySvcs.GetOutwardSupplyTransactionById(Id);
        //    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //}
        //[HttpPut("{id}"), Authorize(policy: "Update")]
        //public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] OutwardSupplyOrderModel model)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var user = await _userManager.GetUserAsync(User);
        //            var result = await _outwardSupplySvcs.UpdateOutwardSupplyTransaction(id, model, user);
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
        //[HttpDelete("{id}"), Authorize(policy: "Delete")]
        //public async Task<IActionResult> Remove([FromRoute] Guid id)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var result = await _outwardSupplySvcs.RemoveOutwardSupplyTransaction(id, user);
        //        return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        //    }
        //    else
        //    {
        //        return BadRequest("Invalid Id");
        //    }
        //}
        #endregion
        #region Recover
        //[HttpGet]
        //public async Task<IActionResult> GetRemoved()
        //{
        //    var result = await _outwardSupplySvcs.GetRemovedOutwardSupplyTransactions();
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
        //            var result = await _outwardSupplySvcs.RecoverOutwardSupplyTransaction(id, user);
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
        //[HttpPost, Authorize(policy: "Update")]
        //public async Task<IActionResult> RecoverAll([FromBody] List<string> Ids)
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    var result = await _outwardSupplySvcs.RecoverAllOutwardSupplyTransactions(Ids, user);
        //    return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        //}
        //[HttpDelete("{id}"), Authorize(policy: "Delete")]
        //public async Task<IActionResult> Delete([FromRoute] Guid id)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var result = await _outwardSupplySvcs.DeleteOutwardSupplyTransaction(id, user);
        //        return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
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
        //    var result = await _outwardSupplySvcs.DeleteAllOutwardSupplyTransactions(Ids, user);
        //    return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        //}
        #endregion
    }
}
