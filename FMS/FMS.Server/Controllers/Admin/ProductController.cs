using FMS.Db.Entity;
using FMS.Svcs.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Admin
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]")]
    public class ProductController(IAdminSvcs adminSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IAdminSvcs _adminSvcs = adminSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Product Type
        [HttpGet, Authorize]
        public async Task<IActionResult> GetProductTypes()
        {
            var result = await _adminSvcs.GetProductTypes();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        #endregion
        #region Unit
        #region Crud
        [HttpPost, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Create")]
        public async Task<IActionResult> CreateUnit([FromBody] UnitModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.CreateUnit(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateUnit), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllUnits()
        {
            var result = await _adminSvcs.GetAllUnits();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPut, Route("{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateUnit([FromRoute] Guid id, [FromBody] UnitModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _adminSvcs.UpdateUnit(id, model, user);
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
        [HttpDelete, Route("Unitid/{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveUnit([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.RemoveUnit(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Recover
        [HttpGet, Authorize(Roles = "Devloper,Admin")]
        public async Task<IActionResult> GetRemovedUnits()
        {
            var result = await _adminSvcs.GetRemovedUnits();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Route("{id}"), Authorize(Roles = "Devloper,Admin"),Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverUnit([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _adminSvcs.RecoverUnit(id, user);
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
        [HttpPost, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverAllUnit([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _adminSvcs.RecoverAllUnit(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete, Route("{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteUnit([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.DeleteUnit(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllUnit([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _adminSvcs.DeleteAllUnit(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
        #endregion
        #region Alternate Unit
        #region Crud
        [HttpPost, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Create")]
        public async Task<IActionResult> CreateAlternateUnit([FromBody] AlternateUnitModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.CreateAlternateUnit(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateAlternateUnit), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpGet, Authorize]
        public async Task<IActionResult> GetAlternateUnits()
        {
            var result = await _adminSvcs.GetAlternateUnits();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPut, Route("{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateAlternateUnit([FromRoute] Guid id, [FromBody] AlternateUnitModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _adminSvcs.UpdateAlternateUnit(id, model, user);
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
        [HttpDelete, Route("Branchid/{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveAlternateUnit([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.RemoveAlternateUnit(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Recover
        [HttpGet, Authorize(Roles = "Devloper,Admin")]
        public async Task<IActionResult> GetRemovedAlternateUnits()
        {
            var result = await _adminSvcs.GetRemovedAlternateUnits();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Route("{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverAlternateUnit([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _adminSvcs.RecoverAlternateUnit(id, user);
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
        [HttpPost, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverAllAlternateUnit([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _adminSvcs.RecoverAllAlternateUnit(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete, Route("{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAlternateUnit([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.DeleteAlternateUnit(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllAlternateUnit([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _adminSvcs.DeleteAllAlternateUnit(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
        #endregion
        #region Product Group
        #region Crud
        [HttpPost, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Create")]
        public async Task<IActionResult> CreateProductGroup([FromBody] ProductGroupModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.CreateProductGroup(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateProductGroup), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpGet ,Authorize]
        public async Task<IActionResult> GetProductGroups()
        {
            var result = await _adminSvcs.GetProductGroups();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPut, Route("{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateProductGroup([FromRoute] Guid id, [FromBody] ProductGroupModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _adminSvcs.UpdateProductGroup(id, model, user);
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
        [HttpDelete, Route("ProductGroupid/{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveProductGroup([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.RemoveProductGroup(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Recover
        [HttpGet, Authorize(Roles = "Devloper,Admin")]
        public async Task<IActionResult> GetRemovedProductGroup()
        {
            var result = await _adminSvcs.GetRemovedProductGroup();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Route("{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverProductGroup([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _adminSvcs.RecoverProductGroup(id, user);
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
        [HttpPost, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverAllProductGroup([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _adminSvcs.RecoverAllProductGroup(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete, Route("{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteProductGroup([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.DeleteProductGroup(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllProductGroup([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _adminSvcs.DeleteAllProductGroup(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
        #endregion
        #region Product SubGroup
        #region Crud
        [HttpPost, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Create")]
        public async Task<IActionResult> CreateProductSubGroup([FromBody] ProductSubGroupModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.CreateProductSubGroup(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateProductSubGroup), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpGet,Authorize]
        public async Task<IActionResult> GetProductSubGroups()
        {
            var result = await _adminSvcs.GetProductSubGroups();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPut, Route("{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateProductSubGroup([FromRoute] Guid id, [FromBody] ProductSubGroupModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _adminSvcs.UpdateProductSubGroup(id, model, user);
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
        [HttpDelete, Route("ProductSubgroupid/{id}"), Authorize(Roles = "Devloper,Admin"),  Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveProductSubGroup([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.RemoveProductSubGroup(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Recover
        [HttpGet,Authorize]
        public async Task<IActionResult> GetRemovedProductSubGroup()
        {
            var result = await _adminSvcs.GetRemovedProductSubGroup();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Route("{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverProductSubGroup([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _adminSvcs.RecoverProductSubGroup(id, user);
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
        [HttpPost, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverAllProductSubGroup([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _adminSvcs.RecoverAllProductSubGroup(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete, Route("{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteProductSubGroup([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.DeleteProductSubGroup(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllProductSubGroup([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _adminSvcs.DeleteAllProductSubGroup(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
        #endregion
        #region Product
        #region Crud
        [HttpPost, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Create")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.CreateProduct(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateProduct), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpGet , Authorize]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _adminSvcs.GetAllProducts();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPut, Route("{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, [FromBody] ProductModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _adminSvcs.UpdateProduct(id, model, user);
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
        [HttpDelete, Route("Productid/{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveProduct([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.RemoveProduct(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        #endregion
        #region Recover
        [HttpGet, Authorize(Roles = "Devloper,Admin")]
        public async Task<IActionResult> GetRemovedProduct()
        {
            var result = await _adminSvcs.GetRemovedProduct();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Route("{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverProduct([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _adminSvcs.RecoverProduct(id, user);
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
        [HttpPost, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverAllProduct([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _adminSvcs.RecoverAllProduct(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete, Route("{id}"), Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _adminSvcs.DeleteProduct(id, user);
                return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }
        [HttpPost, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAllProduct([FromBody] List<string> Ids)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _adminSvcs.DeleteAllProduct(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
        #endregion
    }
}


