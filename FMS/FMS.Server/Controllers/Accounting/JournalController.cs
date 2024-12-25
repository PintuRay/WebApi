using FMS.Db.Entity;
using FMS.Svcs.Accounting.Journal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Accounting
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "User,Admin,Devloper")]
    public class JournalController(IJournalSvcs journalSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IJournalSvcs _journalSvcs = journalSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetJournalVoucherNo()
        {
            var result = await _journalSvcs.GetJournalVoucherNo();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        #region Crud
        [HttpGet]
        public async Task<IActionResult> GetJournals()
        {
            var result = await _journalSvcs.GetJournals();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetJournalById([FromQuery] Guid Id)
        {
            var result = await _journalSvcs.GetJournalById(Id);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPost, Authorize(policy: "Create")]
        public async Task<IActionResult> CreateJournal([FromBody] JournalOrderModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _journalSvcs.CreateJournal(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateJournal), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpDelete, Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveJournal([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _journalSvcs.RemoveJournal(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Recover
        [HttpGet]
        public async Task<IActionResult> GetRemovedJournal()
        {
            var result = await _journalSvcs.GetRemovedJournal();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverJournal([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _journalSvcs.RecoverJournal(id, user);
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
        [HttpPost, Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverAllJournal([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _journalSvcs.RecoverAllJournal(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete, Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteJournal([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _journalSvcs.DeleteJournal(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllJournal([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _journalSvcs.DeleteAllJournal(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
    }
}
