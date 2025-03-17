using FMS.Db.Entity;
using FMS.Model;
using FMS.Svcs.Account.Autherization;
using FMS.Svcs.Account.User;
using FMS.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.RegularExpressions;

namespace FMS.Server.Controllers.Account
{
    [ApiController, Route("[controller]/[action]")]
    public class UserController(IUserSvcs userSvcs, IWebHostEnvironment environment) : ControllerBase
    {
        #region Dependancy
        private readonly IUserSvcs _userSvcs = userSvcs;
        private readonly IWebHostEnvironment _environment = environment;
        #endregion
        #region SignUp 
        [HttpGet]
        public async Task<IActionResult> ValidateToken([FromQuery] string Token)
        {
            if (!string.IsNullOrEmpty(Token))
            {
                string pattern = @"^\d{3}-\d{3}-\d{4}$";
                if (Regex.IsMatch(Token, pattern))
                {
                    var result = await _userSvcs.ValidateToken(Token);
                    return result.ResponseCode switch
                    {
                        200 => StatusCode(200, result),
                        404 => StatusCode(404, result),
                        _ => BadRequest(result)
                    };
                }
            }
            return BadRequest("Invalid Token");
        }
        [HttpGet]
        public async Task<IActionResult> IsEmailInUse([FromQuery] string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                string emailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                if (Regex.IsMatch(email, emailRegex))
                {
                    var result = await _userSvcs.IsEmailInUse(email);
                    return result.ResponseCode switch
                    {
                        200 => StatusCode(200, result),
                        404 => StatusCode(404, result),
                        _ => BadRequest(result)
                    };
                }
            }
            return BadRequest("Invalid email");
        }
        [HttpGet]
        public async Task<IActionResult> IsPhoneNumberInUse([FromQuery] string phoneNumber)
        {
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                string phoneNoRegex = @"^\d{10}$";
                if (Regex.IsMatch(phoneNumber, phoneNoRegex))
                {
                    var result = await _userSvcs.IsPhoneNumberInUse(phoneNumber);
                    return result.ResponseCode switch
                    {
                        200 => StatusCode(200, result),
                        404 => StatusCode(404, result),
                        _ => BadRequest(result)
                    };
                }
            }
            return BadRequest("Invalid data");
        }
        [HttpGet]
        public async Task<IActionResult> IsUserNameExist([FromQuery] string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {

                var result = await _userSvcs.IsUserNameExist(userName);
                return result.ResponseCode switch
                {
                    200 => StatusCode(200, result),
                    404 => StatusCode(404, result),
                    _ => BadRequest(result)
                };
            }
            return BadRequest("Invalid data");
        }
        [HttpPost, Consumes("multipart/form-data")]
        public async Task<IActionResult> SignUp([FromForm] UserModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ProfilePhoto != null)
                {
                    string StorageLocation = "images/ProfilePhoto/";
                    string path = PictureStorage.UploadPhoto(model.ProfilePhoto, StorageLocation);
                    string uploadsFolder = Path.Combine(_environment.WebRootPath, path);
                    await model.ProfilePhoto.CopyToAsync(new FileStream(uploadsFolder, FileMode.Create));
                    if (path != null)
                    {
                        model.PhotoPath = path;
                    }
                }
                var result = await _userSvcs.SignUp(model);
                return result.ResponseCode switch
                {
                    201 => StatusCode(201, result),
                    _ => BadRequest(result)
                };
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        #endregion
        #region User
        [HttpGet, Authorize(Roles = "Admin,Devloper")]
        public async Task<IActionResult> Get([FromQuery] PaginationParams pagination)
        {
            var result = await _userSvcs.GetUsers(pagination);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpGet("{id}"), Authorize(Roles = "User,Admin,Devloper")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            if (id != null)
            {
                var result = await _userSvcs.GetUserById(id);
                return result.ResponseCode == 200 ? Ok(result) : result.ResponseCode == 404 ? NotFound(result) : BadRequest(result);
            }
            else
            {
                return BadRequest("Plz Provide Valid Id");
            }
        }
        [HttpPatch, Authorize(Roles = "User,Admin,Devloper", Policy = "Update")]
        public async Task<IActionResult> Update([FromForm] UserUpdateModel User)
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
                var result = await _userSvcs.UpdateUser(User);
                return result.ResponseCode == 200 ? Ok(result) : result.ResponseCode == 404 ? NotFound(result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpDelete("{id}"), Authorize(Roles = "User,Admin,Devloper", Policy = "Delete")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (id != null)
            {
                var result = await _userSvcs.DeletUser(id);
                return result.ResponseCode == 200 ? Ok(result) : result.ResponseCode == 404 ? NotFound(result) : BadRequest(result);
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpGet, Authorize(Roles = "User,Admin,Devloper")]
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
        #endregion
    }
}
