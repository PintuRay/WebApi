using FMS.Db.Entity;
using FMS.Model;
using FMS.Svcs.Devloper.BranchFinancialYear;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Devloper
{
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper")]
    public class BranchFinancialYearController(IBranchFinancialYearSvcs branchFinancialYearSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IBranchFinancialYearSvcs _branchFinancialYearSvcs = branchFinancialYearSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _branchFinancialYearSvcs.GetBranchFinancialYears();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationParams pagination)
        {
            var result = await _branchFinancialYearSvcs.GetBranchFinancialYears(pagination);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> Create([FromBody] BranchFinancialYearModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchFinancialYearSvcs.CreateBranchFinancialYear(model, user);
                return result.ResponseCode == 201 ? Created(nameof(Create), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> BulkCreate([FromBody] List<BranchFinancialYearModel> listdata)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchFinancialYearSvcs.BulkCreateBranchFinancialYear(listdata, user);
                return result.ResponseCode == 201 ? Created(nameof(BulkCreate), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPatch, Authorize(policy: "Update")]
        public async Task<IActionResult> Update([FromBody] BranchFinancialYearUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchFinancialYearSvcs.UpdateBranchFinancialYear(model, user);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPatch, Authorize(policy: "Update")]
        public async Task<IActionResult> BulkUpdate([FromBody] List<BranchFinancialYearUpdateModel> listdata)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchFinancialYearSvcs.BulkUpdateBranchFinancialYear(listdata, user);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPut("{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchFinancialYearSvcs.RemoveBranchFinancialYear(id, user);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPut, Authorize(policy: "Delete")]
        public async Task<IActionResult> BulkRemove([FromBody] List<Guid> Ids)
        {
            if (Ids.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchFinancialYearSvcs.BulkRemoveBranchFinancialYear(Ids, user);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            else
            {
                return BadRequest("Invalid Ids");
            }
        }
        #endregion
        #region Recover
        [HttpGet]
        public async Task<IActionResult> GetRemoved([FromQuery] PaginationParams pagination)
        {
            var result = await _branchFinancialYearSvcs.GetRemovedBranchFinancialYears(pagination);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPut("{id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> Recover([FromRoute] Guid Id)
        {
            if (Id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _branchFinancialYearSvcs.RecoverBranchFinancialYear(Id, user);
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
        [HttpPut, Authorize(policy: "Update")]
        public async Task<IActionResult> BulkRecover(List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _branchFinancialYearSvcs.BulkRecoverBranchFinancialYear(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            if (Id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchFinancialYearSvcs.DeleteBranchFinancialYear(Id, user);
                return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpDelete, Authorize(policy: "Delete")]
        public async Task<IActionResult> BulkDelete(List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _branchFinancialYearSvcs.BulkDeleteBranchFinancialYear(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        #endregion
    }
}
