using FluentValidation;
using FMS.Db.Entity;
using FMS.Svcs.CommonSvcs;
using FMS.Svcs.Devloper.BranchFinancialYear;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Common
{
    [Produces("application/json")] 
    [ApiController, Route("Common")]
    public class CommonController(
        ICommonSvcs commonSvcs,
        IBranchFinancialYearSvcs branchFinancialYearSvcs,
        UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly ICommonSvcs _commonSvcs = commonSvcs;
        private readonly IBranchFinancialYearSvcs _branchFinancialYearSvcs = branchFinancialYearSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Country
        #region Crud
        [HttpGet("Country/Get"), AllowAnonymous]
        public async Task<IActionResult> GetCountries()
        {
            var result = await _commonSvcs.GetCountries();
            return result.ResponseCode == 204 ? NoContent() : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
        }
        [HttpPost("Country/Create"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Create")]
        public async Task<IActionResult> CreateCountry([FromBody] CountryModel model)
        {
            if (ModelState.IsValid)
            {
                var validator = new CountryValidator();
                var validationResult = validator.Validate(model);
                if (validationResult.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _commonSvcs.CreateCountry(model, user);
                    return result.ResponseCode == 201 ? Created(nameof(CreateCountry), result) : BadRequest(result);
                }
                else
                {
                    var errors = validationResult.Errors.ToArray();
                    return BadRequest(errors);
                }
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPatch("Country/Update"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateCountry([FromBody] CountryUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var validator = new CountryValidator();
                var validationResult = validator.Validate(model);
                if (validationResult.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _commonSvcs.UpdateCountry(model, user);
                    return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
                }
                else
                {
                    var errors = validationResult.Errors.ToArray();
                    return BadRequest(errors);
                }
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPut("Country/Remove/{id}"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveCountry([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.RemoveCountry(id, user);
                return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Recover
        [HttpGet("Country/GetRemoved"), Authorize(Roles = "Admin,Devloper")]
        public async Task<IActionResult> GetRemovedCountries()
        {
            var result = await _commonSvcs.GetRemovedCountries();
            return result.ResponseCode == 204 ? NoContent() : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
        }
        [HttpPut("Country/Recover/{id}"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverCountry([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.RecoverCountry(id, user);
                return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Plz Provide Valid Id");
            }
        }
        [HttpPut("Country/BulkRecover"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> BulkRecoverCountry([FromBody] List<Guid> Ids)
        {
            if (Ids.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.BulkRecoverCountry(Ids, user);
                return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Ids");
            }
        }
        [HttpDelete("Country/Delete/{id}"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteCountry([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.DeleteCountry(id, user);
                return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpDelete("Country/BulkDelete"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Delete")]
        public async Task<IActionResult> BulkDeleteCountry([FromBody] List<Guid> Ids)
        {
            if (Ids.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.BulkDeleteCountry(Ids, user);
                return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Ids");
            }
        }
        #endregion
        #endregion
        #region State
        #region Crud
        [HttpGet("State/Get/{CountryId}"), AllowAnonymous]
        public async Task<IActionResult> GetStates([FromRoute] Guid CountryId)
        {
            var result = await _commonSvcs.GetStates(CountryId);
            return result.ResponseCode == 204 ? NoContent() : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
        }
        [HttpPost("State/Create"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Create")]
        public async Task<IActionResult> CreateState([FromBody] StateModel model)
        {
            if (ModelState.IsValid)
            {
                var validator = new StateValidator();
                var validationResult = validator.Validate(model);
                if (validationResult.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _commonSvcs.CreateState(model, user);
                    return result.ResponseCode == 201 ? Created(nameof(CreateState), result) : BadRequest(result);
                }
                else
                {
                    var errors = validationResult.Errors.ToArray();
                    return BadRequest(errors);
                }
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPatch("State/Update"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateState([FromBody] StateUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var validator = new StateValidator();
                var validationResult = validator.Validate(model);
                if (validationResult.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _commonSvcs.UpdateState(model, user);
                    return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
                }
                else
                {
                    var errors = validationResult.Errors.ToArray();
                    return BadRequest(errors);
                }
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPut("State/Remove/{id}"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveState([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.RemoveState(id, user);
                return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Recover
        [HttpGet("State/GetRemoved"), Authorize(Roles = "Admin,Devloper")]
        public async Task<IActionResult> GetRemovedStates()
        {
            var result = await _commonSvcs.GetRemovedStates();
            return result.ResponseCode == 204 ? NoContent() : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
        }
        [HttpPut("State/Recover/{id}"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverState([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.RecoverState(id, user);
                return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Plz Provide Valid Id");
            }
        }
        [HttpPut("State/BulkRecover"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> BulkRecoverStates([FromBody] List<Guid> Ids)
        {
            if (Ids.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.BulkRecoverStates(Ids, user);
                return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Ids");
            }
        }
        [HttpDelete("State/Delete/{id}"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteState([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.DeleteState(id, user);
                return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpDelete("State/BulkDelete"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Delete")]
        public async Task<IActionResult> BulkDeleteStates([FromBody] List<Guid> Ids)
        {
            if (Ids.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.BulkDeleteStates(Ids, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Ids");
            }
        }
        #endregion
        #endregion
        #region Dist
        #region Crud
        [HttpGet, Route("Dist/Get/{StateId}"), AllowAnonymous]
        public async Task<IActionResult> GetDists([FromRoute] Guid StateId)
        {
            var result = await _commonSvcs.GetDists(StateId);
            return result.ResponseCode == 204 ? NoContent() : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
        }
        [HttpPost, Route("Dist/Create"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Create")]
        public async Task<IActionResult> CreateDist([FromBody] DistModel model)
        {
            if (ModelState.IsValid)
            {
                var validator = new DistValidator();
                var validationResult = validator.Validate(model);
                if (validationResult.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _commonSvcs.CreateDist(model, user);
                    return result.ResponseCode == 201 ? Created(nameof(CreateDist), result) : BadRequest(result);
                }
                else
                {
                    var errors = validationResult.Errors.ToArray();
                    return BadRequest(errors);
                }
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPatch("Dist/Update"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateDist([FromBody] DistUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var validator = new DistValidator();
                var validationResult = validator.Validate(model);
                if (validationResult.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _commonSvcs.UpdateDist(model, user);
                    return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
                }
                else
                {
                    var errors = validationResult.Errors.ToArray();
                    return BadRequest(errors);
                }
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPut, Route("Dist/Remove/{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveDist([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.RemoveDist(id, user);
                return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Recover
        [HttpGet("Dist/GetRemoved"), Authorize(Roles = "Admin,Devloper"),]
        public async Task<IActionResult> GetRemovedDists()
        {
            var result = await _commonSvcs.GetRemovedDists();
            return result.ResponseCode == 204 ? NoContent() : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
        }
        [HttpPut("Dist/Recover/{id}"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverDist([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.RecoverDist(id, user);
                return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Plz Provide Valid Id");
            }
        }
        [HttpPut("Dist/BulkRecover"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> BulkRecoverDists([FromBody] List<Guid> Ids)
        {
            if (Ids.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.BulkRecoverDists(Ids, user);
                return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Ids");
            }
        }
        [HttpDelete("Dist/Delete/{id}"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteDist([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.DeleteDist(id, user);
                return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpDelete("Dist/BulkDelete"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Delete")]
        public async Task<IActionResult> BulkDeleteDists([FromBody] List<Guid> Ids)
        {
            if (Ids.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.BulkDeleteDists(Ids, user);
                return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Ids");
            }
        }
        #endregion
        #endregion
        #region Branch Financial Year
        [HttpGet("BranchFinancialYear/Get/{BranchId}"), AllowAnonymous]
        public async Task<IActionResult> GetBranchFinancialYear([FromRoute] Guid BranchId)
        {
            var result = await _branchFinancialYearSvcs.GetBranchFinancialYears(BranchId);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        #endregion
    }
}
