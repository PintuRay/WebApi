using FMS.Db.Entity;
using FMS.Model;
using FMS.Svcs.Admin.Dist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Admin
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper,Admin")]
    public class DistController(IDistSvcs distSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IDistSvcs _distSvcs = distSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationParams pagination)
        {
            var result = await _distSvcs.GetDists(pagination);
            return result.ResponseCode switch
            {
                404 => NotFound(result),
                200 => Ok(result),
                _ => BadRequest(result)
            };
        }
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> Create([FromBody] DistModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _distSvcs.CreateDist(model, user);
                return result.ResponseCode switch
                {
                    201 => Created(nameof(Create), result),
                    302 => StatusCode(302, result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> BulkCreate([FromBody] List<DistModel> listdata)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _distSvcs.BulkCreateDist(listdata, user);
                return result.ResponseCode switch
                {
                    201 => Created(nameof(BulkCreate), result),
                    302 => StatusCode(302, result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPatch, Authorize(policy: "Update")]
        public async Task<IActionResult> Update([FromBody] DistUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _distSvcs.UpdateDist(model, user);
                return result.ResponseCode switch
                {
                    404 => NotFound(result),
                    200 => Ok(result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPatch, Authorize(policy: "Update")]
        public async Task<IActionResult> BulkUpdate([FromBody] List<DistUpdateModel> listdata)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _distSvcs.BulkUpdateDist(listdata, user);
                return result.ResponseCode switch
                {
                    404 => NotFound(result),
                    200 => Ok(result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPut("Remove/{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveDist([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _distSvcs.RemoveDist(id, user);
                return result.ResponseCode switch
                {
                    404 => NotFound(result),
                    200 => Ok(result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPut, Authorize(policy: "Delete")]
        public async Task<IActionResult> BulkRemove([FromBody] List<DistUpdateModel> listdata)
        {
            if (listdata.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _distSvcs.BulkRemoveDist(listdata, user);
                return result.ResponseCode switch
                {
                    200 => Ok(result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                return BadRequest("Invalid data");
            }
        }
        #endregion
        #region Recover
        [HttpGet]
        public async Task<IActionResult> GetRemoved([FromQuery] PaginationParams pagination)
        {
            var result = await _distSvcs.GetRemovedDists(pagination);
            return result.ResponseCode switch
            {
                404 => NotFound(result),
                200 => Ok(result),
                _ => BadRequest(result)
            };
        }
        [HttpPut, Authorize(policy: "Update")]
        public async Task<IActionResult> Recover([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _distSvcs.RecoverDist(id, user);
                return result.ResponseCode switch
                {
                    404 => NotFound(result),
                    200 => Ok(result),
                    302 => StatusCode(302, result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                return BadRequest("Plz Provide Valid Id");
            }
        }
        [HttpPut, Authorize(policy: "Update")]
        public async Task<IActionResult> BulkRecover([FromBody] List<DistUpdateModel> listdata)
        {
            if (listdata.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _distSvcs.BulkRecoverDists(listdata, user);
                return result.ResponseCode switch
                {
                    200 => Ok(result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                return BadRequest("Invalid data");
            }
        }
        [HttpDelete("{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteDist([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _distSvcs.DeleteDist(id, user);
                return result.ResponseCode switch
                {
                    404 => StatusCode(404, result),
                    200 => StatusCode(200, result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpDelete, Authorize(policy: "Delete")]
        public async Task<IActionResult> BulkDeleteDists([FromBody] List<Guid> Ids)
        {
            if (Ids.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _distSvcs.BulkDeleteDists(Ids, user);
                return result.ResponseCode switch
                {
                    200 => StatusCode(200, result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                return BadRequest("Invalid Ids");
            }
        }
        #endregion
    }
}
