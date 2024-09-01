using FMS.Db.Entity;
using FMS.Svcs.DevloperSetting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Devloper
{
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper")]
    public class FinancialYearController(IDevloperSettingSvcs devloperSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IDevloperSettingSvcs _devloperSvcs = devloperSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> CreateFinancialYear([FromBody] FinancialYearModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _devloperSvcs.CreateFinancialYear(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateFinancialYear), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetFinancialYears()
        {
            var result = await _devloperSvcs.GetFinancialYears();
            return result.ResponseCode == 200 ? Ok(result) : result.ResponseCode ==204? NoContent() :BadRequest(result);
        }
        [HttpPut, Route("{Id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateFinancialYear([FromRoute] Guid Id, [FromBody] FinancialYearModel model)
        {
            if (Id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _devloperSvcs.UpdateFinancialYear(Id, model, user);
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
        [HttpDelete, Route("FinancialYearId/{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveFinancialYear([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _devloperSvcs.RemoveFinancialYear(id, user);
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
        public async Task<IActionResult> GetRemovedFinancialYears()
        {
            var result = await _devloperSvcs.GetRemovedFinancialYears();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Route("{Id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverFinancialYear(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _devloperSvcs.RecoverFinancialYear(Id, user);
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
        [HttpDelete, Route("{Id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteFinancialYear(Guid Id)
        {
            if (Id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _devloperSvcs.DeleteFinancialYear(Id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverAllFinancialYear(List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _devloperSvcs.RecoverAllFinancialYear(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpPost, Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllFinancialYear(List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _devloperSvcs.DeleteAllFinancialYear(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
    }
}
