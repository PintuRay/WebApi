using FMS.Db.Entity;
using FMS.Svcs.Admin.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Admin
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper,Admin")]
    public class CompanyController(ICompanySvcs companySvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly ICompanySvcs _companySvcs = companySvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyModel data)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _companySvcs.CreateCompany(data, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateCompany), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetCompany([FromQuery] string BranchId)
        {
            var result = await _companySvcs.GetCompany(BranchId);
            return result.ResponseCode == 200 ? Ok(result) : result.ResponseCode == 204 ? NoContent() : BadRequest(result);
        }
        [HttpPut, Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateBranch([FromQuery] Guid id, [FromBody] CompanyModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _companySvcs.UpdateCompany(id, model, user);
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
        [HttpDelete,Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveCompany([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _companySvcs.RemoveCompany(id, user);
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
        public async Task<IActionResult> GetRemovedCompanies([FromQuery] string BranchId)
        {
            var result = await _companySvcs.GetRemovedCompanies(BranchId);
            return result.ResponseCode == 200 ? Ok(result) : result.ResponseCode == 204 ? NoContent() : BadRequest(result);
        }
        [HttpPatch, Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverCompany([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _companySvcs.RecoverCompany(id, user);
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
        public async Task<IActionResult> RecoverAllCompany([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _companySvcs.RecoverAllCompany(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete, Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteCompany([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _companySvcs.DeleteCompany(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllCompany([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _companySvcs.DeleteAllCompany(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
    }
}
