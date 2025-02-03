using FluentValidation;
using FMS.Db.Entity;
using FMS.Model;
using FMS.Svcs.Devloper.FinancialYear;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Devloper
{
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "Devloper")]
    public class FinancialYearController(IFinancialYearSvcs financialYearSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IFinancialYearSvcs _financialYearSvcs = financialYearSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Crud
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _financialYearSvcs.GetFinancialYears();
            return result.ResponseCode switch
            {
                404 => NotFound(result),
                200 => Ok(result),
                _ => BadRequest(result)
            };
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaginationParams pagination)
        {
           
            var result = await _financialYearSvcs.GetFinancialYears(pagination);
            return result.ResponseCode switch
            {
                404 => NotFound(result),
                200 => Ok(result),
                _ => BadRequest(result)
            };
        }
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> Create([FromBody] FinancialYearModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _financialYearSvcs.CreateFinancialYear(model, user);
                return result.ResponseCode switch
                {
                    201 => Created(nameof(Create), result),
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
        public async Task<IActionResult> BulkCreate([FromBody] List<FinancialYearModel> listdata)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _financialYearSvcs.BulkCreateFinancialYear(listdata, user);
                return result.ResponseCode switch
                {
                    201 => Created(nameof(BulkCreate), result),
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
        public async Task<IActionResult> Update([FromBody] FinancialYearUpdateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _financialYearSvcs.UpdateFinancialYear(model, user);
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
        public async Task<IActionResult> BulkUpdate([FromBody] List<FinancialYearUpdateModel> listdata)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _financialYearSvcs.BulkUpdateFinancialYear(listdata, user);
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
                var result = await _financialYearSvcs.RemoveFinancialYear(id, user);
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
        public async Task<IActionResult> BulkRemove([FromBody] List<Guid> Ids)
        {
            if (Ids.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _financialYearSvcs.BulkRemoveFinancialYear(Ids, user);
                return result.ResponseCode switch
                {
                    404 => NotFound(result),
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
        #region Recover
        [HttpGet]
        public async Task<IActionResult> GetRemoved([FromQuery] PaginationParams pagination)
        {
            var result = await _financialYearSvcs.GetRemovedFinancialYears(pagination);
            return result.ResponseCode switch
            {
                404 => NotFound(result),
                200 => Ok(result),
                _ => BadRequest(result)
            };
        }
        [HttpPut("{id}"), Authorize(policy: "Update")]
        public async Task<IActionResult> Recover([FromRoute] Guid Id)
        {
            if (Id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _financialYearSvcs.RecoverFinancialYear(Id, user);
                return result.ResponseCode switch
                {
                    404 => NotFound(result),
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
        public async Task<IActionResult> BulkRecover([FromBody] List<Guid> Ids)
        {
            if (Ids.Count != 0)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _financialYearSvcs.BulkRecoverFinancialYear(Ids, user);
                return result.ResponseCode switch
                {
                    404 => NotFound(result),
                    200 => Ok(result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                return BadRequest("Invalid Ids");
            }
        }
        [HttpDelete("{id}"), Authorize(policy: "Delete")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            if (Id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _financialYearSvcs.DeleteFinancialYear(Id, user);
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
                var result = await _financialYearSvcs.BulkDeleteFinancialYear(Ids, user);
                return result.ResponseCode switch
                {
                    404 => NotFound(result),
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
    }
}
