using FMS.Db.Entity;
using FMS.Svcs.Transaction;
using FMS.Svcs.Transaction.SalesReturn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Transaction
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "User,Admin,Devloper")]
    public class SalesReturnController(ISalesReturnSvcs salesReturnSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly ISalesReturnSvcs _salesReturnSvcs = salesReturnSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> CreateSalesReturnTransaction([FromBody] SalesReturnOrderModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _salesReturnSvcs.CreateSaleReturnTransaction(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateSalesReturnTransaction), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetSaleReturnTransactions()
        {
            var result = await _salesReturnSvcs.GetSaleReturnsTransactions();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPut,  Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateSaleReturnTransaction([FromQuery] Guid id, [FromBody] SalesReturnOrderModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _salesReturnSvcs.UpdateSaleReturnTransaction(id, model, user);
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
        [HttpDelete,  Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveSaleReturnTransaction([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _salesReturnSvcs.RemoveSaleReturnTransaction(id, user);
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
        public async Task<IActionResult> GetRemovedSaleReturnTransactions()
        {
            var result = await _salesReturnSvcs.GetRemovedSaleReturnTransactions();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch,  Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverSaleReturnTransaction([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _salesReturnSvcs.RecoverSaleReturnTransaction(id, user);
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
        public async Task<IActionResult> RecoverAllSaleReturnTransactions([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _salesReturnSvcs.RecoverAllSaleReturnTransactions(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete,  Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteSaleReturnTransaction([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _salesReturnSvcs.DeleteSaleReturnTransaction(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllSaleReturnTransactions([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _salesReturnSvcs.DeleteAllSaleReturnTransactions(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
    }
}
