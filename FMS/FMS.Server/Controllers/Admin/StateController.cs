using FMS.Db.Entity;
using FMS.Model;
using FMS.Svcs.Common.State;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Admin
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper,Admin")]
    public class StateController(IStateSvcs stateSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IStateSvcs _stateSvcs = stateSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationParams pagination)
        {
            var result = await _stateSvcs.GetStates(pagination);
            return result.ResponseCode switch
            {
                404 => NotFound(result),
                200 => Ok(result),
                _ => BadRequest(result)
            };
        }
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> Create([FromBody] StateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _stateSvcs.CreateState(model, user);
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
        public async Task<IActionResult> BulkCreate([FromBody] List<StateModel> listdata)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _stateSvcs.BulkCreateState(listdata, user);
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
        public async Task<IActionResult> Update([FromBody] StateUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _stateSvcs.UpdateState(model, user);
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
        public async Task<IActionResult> BulkUpdate([FromBody] List<StateUpdateModel> listdata)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _stateSvcs.BulkUpdateState(listdata, user);
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
        [HttpPut("{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _stateSvcs.RemoveState(id, user);
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
        public async Task<IActionResult> BulkRemove([FromBody] List<StateUpdateModel> listdata)
        {
            if (listdata.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _stateSvcs.BulkRemoveState(listdata, user);
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
            var result = await _stateSvcs.GetRemovedStates(pagination);
            return result.ResponseCode switch
            {
                404 => NotFound(result),
                200 => Ok(result),
                _ => BadRequest(result)
            };
        }
        [HttpPut("{id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> Recover([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _stateSvcs.RecoverState(id, user);
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
        public async Task<IActionResult> BulkRecover([FromBody] List<StateUpdateModel> listdata)
        {
            if (listdata.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _stateSvcs.BulkRecoverStates(listdata, user);
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
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _stateSvcs.DeleteState(id, user);
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
        [HttpDelete, Authorize(policy: "Delete")]
        public async Task<IActionResult> BulkDelete([FromBody] List<Guid> Ids)
        {
            if (Ids.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _stateSvcs.BulkDeleteStates(Ids, user);
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
