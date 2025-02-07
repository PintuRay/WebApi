using FMS.Db.Entity;
using FMS.Model;
using FMS.Svcs.Devloper.Branch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Devloper
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper")]
    public class BranchController(IBranchSvcs branchSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IBranchSvcs _branchSvcs = branchSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var result = await _branchSvcs.GetAllBranch();
            // await Task.Delay(3000);
            return result.ResponseCode switch
            {
                404 => StatusCode(404, result),
                200 => StatusCode(200, result),
                _ => BadRequest(result)
            };
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationParams pagination)
        {

            var result = await _branchSvcs.GetAllBranch(pagination);
            //await Task.Delay(3000);
            return result.ResponseCode switch
            {
                404 => StatusCode(404, result),
                200 => StatusCode(200, result),
                _ => BadRequest(result)
            };
        }
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> Create([FromBody] BranchModel data)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchSvcs.CreateBranch(data, user);
                return result.ResponseCode switch
                {
                    201 => StatusCode(201, result),
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
        public async Task<IActionResult> BulkCreate([FromBody] List<BranchModel> listdata)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchSvcs.BulkCreateBranch(listdata, user);
                return result.ResponseCode switch
                {
                    201 => StatusCode(201, result),
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
        public async Task<IActionResult> Update([FromBody] BranchUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchSvcs.UpdateBranch(model, user);
                return result.ResponseCode switch
                {
                    404 => StatusCode(404, result),
                    200 => StatusCode(200, result),
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
        public async Task<IActionResult> BulkUpdate([FromBody] List<BranchUpdateModel> listdata)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchSvcs.BulkUpdateBranch(listdata, user);
                return result.ResponseCode switch
                {
                    404 => StatusCode(404, result),
                    200 => StatusCode(200, result),
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
                var result = await _branchSvcs.RemoveBranch(id, user);
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
        [HttpPut, Authorize(policy: "Delete")]
        public async Task<IActionResult> BulkRemove([FromBody] List<BranchUpdateModel> listdata)
        {
            if (listdata.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchSvcs.BulkRemoveBranch(listdata, user);
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
        #region Recover
        [HttpGet]
        public async Task<IActionResult> GetRemoved([FromQuery] PaginationParams pagination)
        {
            var result = await _branchSvcs.GetRemovedBranches(pagination);
            return result.ResponseCode switch
            {
                404 => StatusCode(404, result),
                200 => StatusCode(200, result),
                _ => BadRequest(result)
            };
        }
        [HttpPut("{id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> Recover([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchSvcs.RecoverBranch(id, user);
                return result.ResponseCode switch
                {
                    404 => StatusCode(404, result),
                    200 => StatusCode(200, result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                return BadRequest("Plz Provide Valid Id");
            }
        }
        [HttpPut, Authorize(policy: "Update")]
        public async Task<IActionResult> BulkRecover([FromBody] List<BranchUpdateModel> listdata)
        {
            if (listdata.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchSvcs.BulkRecoverBranch(listdata, user);
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
        [HttpDelete("{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchSvcs.DeleteBranch(id, user);
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
        public async Task<IActionResult> BulkDelete([FromBody] List<Guid> Ids)
        {
            if (Ids.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _branchSvcs.BulkDeleteBranch(Ids, user);
                return result.ResponseCode switch
                {
                    404 => StatusCode(404, result),
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
