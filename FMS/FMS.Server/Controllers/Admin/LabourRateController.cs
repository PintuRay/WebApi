using FMS.Db.Entity;
using FMS.Svcs.Admin.LabourRate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Admin
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper,Admin")]
    public class LabourRateController(ILabourRateSvcs labourRateSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly ILabourRateSvcs _labourRateSvcs = labourRateSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> CreateLabourRate([FromBody] LabourRateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _labourRateSvcs.CreateLabourRate(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateLabourRate), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLabourRates([FromQuery] Guid FinancialYearId, Guid BranchId)
        {
            var result = await _labourRateSvcs.GetAllLabourRates(FinancialYearId, BranchId);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPut, Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateLabourRate([FromQuery] Guid id, [FromBody] LabourRateModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _labourRateSvcs.UpdateLabourRate(id, model, user);
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
        [HttpDelete, Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveLabourRate([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _labourRateSvcs.RemoveLabourRate(id, user);
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
        public async Task<IActionResult> GetRemovedLabourRate([FromQuery] Guid FinancialYearId, [FromQuery] Guid BranchId)
        {
            var result = await _labourRateSvcs.GetRemovedLabourRate(FinancialYearId, BranchId);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverLabourRate([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _labourRateSvcs.RecoverLabourRate(id, user);
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
        public async Task<IActionResult> RecoverAllLabourRate([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _labourRateSvcs.RecoverAllLabourRate(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete,  Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteLabourRate([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _labourRateSvcs.DeleteLabourRate(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllLabourRate([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _labourRateSvcs.DeleteAllLabourRate(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
    }
}
