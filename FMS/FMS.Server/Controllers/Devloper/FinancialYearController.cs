using FMS.Db.Entity;
using FMS.Model;
using FMS.Svcs.Devloper.FinancialYear;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Devloper
{
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper")]
    public class FinancialYearController(IFinancialYearSvcs financialYearSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IFinancialYearSvcs _financialYearSvcs = financialYearSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        [HttpGet]
        public async Task<IActionResult> GetFinancialYears(PaginationParams pagination)
        {
            var result = await _financialYearSvcs.GetFinancialYears(pagination);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> CreateFinancialYear([FromBody] FinancialYearModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _financialYearSvcs.CreateFinancialYear(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateFinancialYear), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPut, Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateFinancialYear([FromQuery] Guid Id, [FromBody] FinancialYearModel model)
        {
            if (Id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _financialYearSvcs.UpdateFinancialYear(Id, model, user);
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
        public async Task<IActionResult> RemoveFinancialYear([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _financialYearSvcs.RemoveFinancialYear(id, user);
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
        public async Task<IActionResult> GetRemovedFinancialYears(PaginationParams pagination)
        {
            var result = await _financialYearSvcs.GetRemovedFinancialYears(pagination);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverFinancialYear([FromQuery] Guid Id)
        {
            if (Id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _financialYearSvcs.RecoverFinancialYear(Id, user);
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
        public async Task<IActionResult> DeleteFinancialYear([FromQuery] Guid Id)
        {
            if (Id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _financialYearSvcs.DeleteFinancialYear(Id, user);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
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
            var result = await _financialYearSvcs.RecoverAllFinancialYear(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPost, Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllFinancialYear(List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _financialYearSvcs.DeleteAllFinancialYear(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        #endregion
    }
}
