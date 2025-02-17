using FMS.Db.Entity;
using FMS.Svcs.Admin.State;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController(IStateSvcs stateSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IStateSvcs _stateSvcs = stateSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        [HttpGet("State/Get/{CountryId}"), AllowAnonymous]
        public async Task<IActionResult> GetStates([FromRoute] Guid CountryId)
        {
            var result = await _stateSvcs.GetStates(CountryId);
            return result.ResponseCode switch
            {
                404 => StatusCode(404, result),
                200 => StatusCode(200, result),
                _ => BadRequest(result)
            };
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
                    var result = await _stateSvcs.CreateState(model, user);
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
                    var result = await _stateSvcs.UpdateState(model, user);
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
                var result = await _stateSvcs.RemoveState(id, user);
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
            var result = await _stateSvcs.GetRemovedStates();
            return result.ResponseCode == 204 ? NoContent() : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
        }
        [HttpPut("State/Recover/{id}"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverState([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _stateSvcs.RecoverState(id, user);
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
                var result = await _stateSvcs.BulkRecoverStates(Ids, user);
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
                var result = await _stateSvcs.DeleteState(id, user);
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
                var result = await _stateSvcs.BulkDeleteStates(Ids, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Ids");
            }
        }
        #endregion
    }
}
