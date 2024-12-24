using FMS.Db.Entity;
using FMS.Svcs.CommonSvcs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Common
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]")]
    public class CommonController(ICommonSvcs commonSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly ICommonSvcs _commonSvcs = commonSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Country
        #region Crud
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetCountries()
        {
            var result = await _commonSvcs.GetCountries();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPost, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Create")]
        public async Task<IActionResult> CreateCountry([FromBody] CountryModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.CreateCountry(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateState), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpPut, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateCountry([FromRoute] Guid id, [FromBody] CountryModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _commonSvcs.UpdateCountry(id, model, user);
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
        [HttpDelete, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveCountry([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.RemoveCountry(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Recover
        [HttpGet, Authorize(Roles = "Admin,Devloper")]
        public async Task<IActionResult> GetRemovedCountries()
        {
            var result = await _commonSvcs.GetRemovedCountries();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverCountry([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _commonSvcs.RecoverCountry(id, user);
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
        [HttpPost, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverAllCountry([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _commonSvcs.RecoverAllCountry(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteCountry([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.DeleteCountry(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllCountry([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _commonSvcs.DeleteAllCountry(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
        #endregion
        #region State
        #region Crud
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetStates([FromRoute] Guid CountryId)
        {
            var result = await _commonSvcs.GetStates(CountryId);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPost, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Create")]
        public async Task<IActionResult> CreateState([FromBody] StateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.CreateState(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateState), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
   
        [HttpPut, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateState([FromRoute] Guid id, [FromBody] StateModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _commonSvcs.UpdateState(id, model, user);
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
        [HttpDelete, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveState([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.RemoveState(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Recover
        [HttpGet, Authorize(Roles = "Admin,Devloper")]
        public async Task<IActionResult> GetRemovedStates()
        {
            var result = await _commonSvcs.GetRemovedStates();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverState([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _commonSvcs.RecoverState(id, user);
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
        [HttpPost, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverAllStates([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _commonSvcs.RecoverAllStates(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteState([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.DeleteState(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllStates([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _commonSvcs.DeleteAllStates(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
        #endregion
        #region Dist
        #region Crud
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetDists([FromRoute] Guid StateId)
        {
            var result = await _commonSvcs.GetDists(StateId);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPost, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Create")]
        public async Task<IActionResult> CreateDist([FromBody] DistModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.CreateDist(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateDist), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }

        [HttpPut, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateDist([FromRoute] Guid id, [FromBody] DistModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _commonSvcs.UpdateDist(id, model, user);
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
        [HttpDelete, Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveDist([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.RemoveDist(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Recover
        [HttpGet, Authorize(Roles = "Admin,Devloper"),]
        public async Task<IActionResult> GetRemovedDists()
        {
            var result = await _commonSvcs.GetRemovedDists();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverDist([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _commonSvcs.RecoverDist(id, user);
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
        [HttpPost, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverAllDists([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _commonSvcs.RecoverAllDists(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteDist([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _commonSvcs.DeleteDist(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(Roles = "Admin,Devloper"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllDists([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _commonSvcs.DeleteAllDists(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
        #endregion
    }
}
