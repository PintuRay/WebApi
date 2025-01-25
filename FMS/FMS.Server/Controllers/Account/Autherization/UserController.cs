using FMS.Db.Entity;
using FMS.Model.Account.Authentication;
using FMS.Model.Account.Autherization;
using FMS.Svcs.Account.Autherization;
using FMS.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FMS.Server.Controllers.Account.Autherization
{
    [ApiController, Route("[controller]/[action]"), Authorize(Roles = "User,Admin,Devloper")]
    public class UserController(IAutherizationSvcs autherizationSvcs, IWebHostEnvironment environment) : ControllerBase
    {
        #region Dependancy
        private readonly IAutherizationSvcs _autherizationSvcs = autherizationSvcs;
        private readonly IWebHostEnvironment _environment = environment;
        #endregion
        #region User
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _autherizationSvcs.GetUsers();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> GetByMail([FromRoute] string email)
        {
            if (email != null)
            {
                var result = await _autherizationSvcs.GetUserByMail(email);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Plz Provide Valid Mail");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            if (id != null)
            {
                var result = await _autherizationSvcs.GetUserById(id);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Plz Provide Valid Id");
            }
        }
        [HttpGet]
        public IActionResult GetImage([FromQuery] string filename)
        {
            var decodedFilename = WebUtility.UrlDecode(filename);
            var actualFilename = Path.GetFileName(decodedFilename);
            var path = Path.Combine(_environment.WebRootPath, "images/ProfilePhoto", actualFilename);
            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }
            return PhysicalFile(path, PictureStorage.GetContentType(path));
        }
        [HttpPatch, Authorize(Policy = "Update")]
        public async Task<IActionResult> Update([FromForm] UserModel User)
        {
            if (ModelState.IsValid)
            {
                if (User.ProfilePhoto != null)
                {
                    string StorageLocation = "images/ProfilePhoto/";
                    string newPhotoPath = PictureStorage.UploadPhoto(User.ProfilePhoto, StorageLocation);
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, newPhotoPath);
                    await User.ProfilePhoto.CopyToAsync(new FileStream(uploadsFolder, FileMode.Create));
                    if (!string.IsNullOrEmpty(User.PhotoPath))
                    {
                        string existingPhotoPath = Path.Combine(_environment.WebRootPath, User.PhotoPath);
                        if (System.IO.File.Exists(existingPhotoPath))
                        {
                            System.IO.File.Delete(existingPhotoPath);
                        }
                    }
                    User.PhotoPath = newPhotoPath;
                }
                var result = await _autherizationSvcs.UpdateUser(User);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpDelete("{id}"), Authorize(Policy = "Delete")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (id != null)
            {
                var result = await _autherizationSvcs.DeletUser(id);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
    }
}
