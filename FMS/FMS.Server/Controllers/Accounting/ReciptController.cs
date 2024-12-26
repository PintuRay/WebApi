using FMS.Db.Entity;
using FMS.Svcs.Accounting.Receipt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Accounting
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "User,Admin,Devloper")]
    public class ReciptController(IReceiptSvcs receiptSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IReceiptSvcs _receiptSvcs = receiptSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        //[HttpGet]
        //public async Task<IActionResult> GetReceiptVoucherNo([FromQuery] string CashBank)
        //{
        //    var result = await _receiptSvcs.GetReceiptVoucherNo(CashBank);
        //    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //}
        #region Crud
        //[HttpPost, Authorize(policy: "Create")]
        //public async Task<IActionResult> Create([FromBody] ReceiptOrderModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var result = await _receiptSvcs.CreateRecipt(model, user);
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
        //    var result = await _receiptSvcs.GetReceipts();
        //    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetById([FromRoute] Guid Id)
        //{
        //    var result = await _receiptSvcs.GetReceiptById(Id);
        //    return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        //}
        //[HttpDelete("{id}"), Authorize(policy: "Delete")]
        //public async Task<IActionResult> Removed([FromRoute] Guid id)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var result = await _receiptSvcs.RemoveReceipt(id, user);
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
        //    var result = await _receiptSvcs.GetRemovedReceipt();
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
        //            var result = await _receiptSvcs.RecoverReceipt(id, user);
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
        //    var result = await _receiptSvcs.RecoverAllReceipt(Ids, user);
        //    return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        //}
        //[HttpDelete("{id}"), Authorize(policy: "Delete")]
        //public async Task<IActionResult> Delete([FromRoute] Guid id)
        //{
        //    if (id != Guid.Empty)
        //    {
        //        var user = await _userManager.GetUserAsync(User);
        //        var result = await _receiptSvcs.DeleteReceipt(id, user);
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
        //    var result = await _receiptSvcs.DeleteAllReceipt(Ids, user);
        //    return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        //}
        #endregion
    }
}
