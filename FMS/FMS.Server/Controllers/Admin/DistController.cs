using FMS.Db.Entity;
using FMS.Svcs.Admin.Dist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistController(IDistSvcs distSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IDistSvcs _distSvcs = distSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        [HttpGet, Route("Dist/Get/{StateId}"), AllowAnonymous]
        public async Task<IActionResult> GetDists([FromRoute] Guid StateId)
        {
            var result = await _distSvcs.GetDists(StateId);
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
                    var result = await _distSvcs.CreateDist(model, user);
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
                    var result = await _distSvcs.UpdateDist(model, user);
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
                var result = await _distSvcs.RemoveDist(id, user);
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
            var result = await _distSvcs.GetRemovedDists();
            return result.ResponseCode == 204 ? NoContent() : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
        }
        [HttpPut("Dist/Recover/{id}"), Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverDist([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _distSvcs.RecoverDist(id, user);
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
                var result = await _distSvcs.BulkRecoverDists(Ids, user);
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
                var result = await _distSvcs.DeleteDist(id, user);
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
                var result = await _distSvcs.BulkDeleteDists(Ids, user);
                return result.ResponseCode == 404 ? NotFound(result) : (result.ResponseCode == 200 ? Ok(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Ids");
            }
        }
        #endregion
    }
}
