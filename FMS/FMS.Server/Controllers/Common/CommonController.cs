using FMS.Db.Entity;
using FMS.Svcs.Account.User;
using FMS.Svcs.Admin.UserBranch;
using FMS.Svcs.Common.Country;
using FMS.Svcs.Common.Dist;
using FMS.Svcs.Common.State;
using FMS.Svcs.Devloper.Branch;
using FMS.Svcs.Devloper.FinancialYear;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Common
{
    [Produces("application/json")]
    [ApiController, Route("Common")]
    public class CommonController(
        IBranchSvcs branchSvcs,
        IUserSvcs userSvcs,
        ICountrySvcs countrySvcs ,
        IStateSvcs stateSvcs,
        IDistSvcs distSvcs,
        IFinancialYearSvcs financialYearSvcs,
        IUserBranchSvcs userBranchSvcs,
        UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IBranchSvcs _branchSvcs = branchSvcs;
        private readonly ICountrySvcs _countrySvcs = countrySvcs;
        private readonly IStateSvcs _stateSvcs = stateSvcs;
        private readonly IDistSvcs _distSvcs = distSvcs;
        private readonly IFinancialYearSvcs _financialYearSvcs = financialYearSvcs;
        private readonly IUserBranchSvcs _userBranchSvcs = userBranchSvcs;
        private readonly IUserSvcs _userSvcs = userSvcs;
       private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        [HttpGet("Users/Get")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userSvcs.GetUsers();
            return result.ResponseCode switch
            {
                404 => StatusCode(404, result),
                200 => StatusCode(200, result),
                _ => BadRequest(result)
            };
        }
        [HttpGet("Branch/Get")]
        public async Task<IActionResult> GetBranches()
        {
            var result = await _branchSvcs.GetAllBranch();
            return result.ResponseCode switch
            {
                404 => StatusCode(404, result),
                200 => StatusCode(200, result),
                _ => BadRequest(result)
            };
        }
        [HttpGet("FinancialYear/Get/{BranchId}")]
        public async Task<IActionResult> GetFinancialYear([FromRoute] Guid BranchId)
        {
            var result = await _financialYearSvcs.GetFinancialYears(BranchId);
            return result.ResponseCode switch
            {
                404 => NotFound(result),
                200 => Ok(result),
                _ => BadRequest(result)
            };
        }
        [HttpGet("UserBranch/Get")]
        public async Task<IActionResult> GetUserBranches()
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _userBranchSvcs.GetUserBranches(user);
            return result.ResponseCode switch
            {
                404 => StatusCode(404, result),
                200 => StatusCode(200, result),
                _ => BadRequest(result)
            };
        }
        [HttpGet("Country/Get")]
        public async Task<IActionResult> GetCountries()
        {
            var result = await _countrySvcs.GetCountries();
            return  result.ResponseCode switch
            {
                404 => NotFound(result),
                200 => Ok(result),
                _ => BadRequest(result)
            };
        }
        [HttpGet("State/Get/{CountryId}")]
        public async Task<IActionResult> GetStates([FromRoute] Guid CountryId)
        {
            var result = await _stateSvcs.GetStates(CountryId);
            return result.ResponseCode switch
            {
                404 => NotFound(result),
                200 => Ok(result),
                _ => BadRequest(result)
            };
        }
        [HttpGet, Route("Dist/Get/{StateId}")]
        public async Task<IActionResult> GetDists([FromRoute] Guid StateId)
        {
            var result = await _distSvcs.GetDists(StateId);
            return result.ResponseCode switch
            {
                404 => NotFound(result),
                200 => Ok(result),
                _ => BadRequest(result)
            };
        }
    }
}
