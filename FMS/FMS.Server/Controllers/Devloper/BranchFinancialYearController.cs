using FMS.Db.Entity;
using FMS.Model.Devloper;
using FMS.Svcs.DevloperSetting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Devloper
{
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper")]
    public class BranchFinancialYearController(IDevloperSettingSvcs devloperSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IDevloperSettingSvcs _devloperSvcs = devloperSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> CreateBranchFinancialYear([FromBody] BranchFinancialYearModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _devloperSvcs.CreateBranchFinancialYear(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateBranchFinancialYear), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetBranchFinancialYears()
        {
            var result = await _devloperSvcs.GetFinancialYears();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }

        [HttpPut, Route("{Id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateBranchFinancialYear([FromRoute] Guid Id, [FromBody] BranchFinancialYearModel model)
        {
            if (Id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _devloperSvcs.UpdateBranchFinancialYear(Id, model, user);
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
        [HttpDelete, Route("BranchFinancialYearId/{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveBranchFinancialYear([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _devloperSvcs.RemoveBranchFinancialYear(id, user);
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
        public async Task<IActionResult> GetRemovedBranchFinancialYears() 
        {
            var result = await _devloperSvcs.GetRemovedBranchFinancialYears();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Route("{Id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverBranchFinancialYear(Guid Id) 
        {
            if (Id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _devloperSvcs.RecoverBranchFinancialYear(Id, user);
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
        public async Task<IActionResult> DeleteBranchFinancialYear(Guid Id) 
        {
            if (Id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _devloperSvcs.DeleteBranchFinancialYear(Id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverAllBranchFinancialYear(List<string> Ids) 
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _devloperSvcs.RecoverAllBranchFinancialYear(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpPost, Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllBranchFinancialYear(List<string> Ids) 
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _devloperSvcs.DeleteAllBranchFinancialYear(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
    }
}
