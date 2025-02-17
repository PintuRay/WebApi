using FMS.Db.Entity;
using FMS.Model;
using FMS.Svcs.Admin.Country;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Admin
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper,Admin")]
    public class CountryController(UserManager<AppUser> userManager, ICountrySvcs countrySvcs) : ControllerBase
    {
        private readonly ICountrySvcs _countrySvcs = countrySvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #region Country
        #region Crud
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationParams pagination)
        {
            var result = await _countrySvcs.GetCountries(pagination);
            return result.ResponseCode switch
            {
                404 => NotFound(result),
                200 => Ok(result),
                _ => BadRequest(result)
            };
        }
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> Create([FromBody] CountryModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _countrySvcs.CreateCountry(model, user);
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
        public async Task<IActionResult> BulkCreate([FromBody] List<CountryModel> listdata)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _countrySvcs.BulkCreateCountry(listdata, user);
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
        public async Task<IActionResult> Update([FromBody] CountryUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _countrySvcs.UpdateCountry(model, user);
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
        public async Task<IActionResult> BulkUpdate([FromBody] List<CountryUpdateModel> listdata)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _countrySvcs.BulkUpdateCountry(listdata, user);
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
        [HttpPut("remove/{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> Remove([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _countrySvcs.RemoveCountry(id, user);
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
        public async Task<IActionResult> BulkRemove([FromBody] List<CountryUpdateModel> listdata)
        {
            if (listdata.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _countrySvcs.BulkRemoveCountry(listdata, user);
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
            var result = await _countrySvcs.GetRemovedCountries(pagination);
            return result.ResponseCode switch
            {
                404 => NotFound(result),
                200 => Ok(result),
                _ => BadRequest(result)
            };
        }
        [HttpPut("Recover/{id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> Recover([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _countrySvcs.RecoverCountry(id, user);
                return result.ResponseCode switch
                {
                    404 => NotFound(result),
                    302 => StatusCode(302, result),
                    200 => Ok(result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                return BadRequest("Plz Provide Valid Id");
            }
        }
        [HttpPut, Authorize(policy: "Update")]
        public async Task<IActionResult> BulkRecover([FromBody] List<CountryUpdateModel> listdata)
        {
            if (listdata.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _countrySvcs.BulkRecoverCountry(listdata, user);
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
                var result = await _countrySvcs.DeleteCountry(id, user);
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
                var result = await _countrySvcs.BulkDeleteCountry(Ids, user);
                return result.ResponseCode switch
                {
                    200 => Ok(result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                return BadRequest("Invalid Ids");
            }
        }
        #endregion
        #endregion
    }
}
