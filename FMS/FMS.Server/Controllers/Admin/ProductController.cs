using FMS.Db.Entity;
using FMS.Svcs.Admin.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers.Admin
{
    [Produces("application/json")]
    [ApiController, Route("[controller]/[action]")]
    public class ProductController(IProductSvcs productSvcs, UserManager<AppUser> userManager) : ControllerBase
    {
        #region Dependancy
        private readonly IProductSvcs _productSvcs = productSvcs;
        private readonly UserManager<AppUser> _userManager = userManager;
        #endregion
        #region Product Type
        [HttpGet, Authorize]
        public async Task<IActionResult> GetProductTypes()
        {
            var result = await _productSvcs.GetProductTypes();
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
                var result = await _productSvcs.CreateUnit(model, user);
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
            var result = await _productSvcs.GetAllUnits();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPut,  Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateUnit([FromQuery] Guid id, [FromBody] UnitModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _productSvcs.UpdateUnit(id, model, user);
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
        [HttpDelete, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveUnit([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _productSvcs.RemoveUnit(id, user);
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
            var result = await _productSvcs.GetRemovedUnits();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch,  Authorize(Roles = "Devloper,Admin"),Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverUnit([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _productSvcs.RecoverUnit(id, user);
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
            var result = await _productSvcs.RecoverAllUnit(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteUnit([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _productSvcs.DeleteUnit(id, user);
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
            var result = await _productSvcs.DeleteAllUnit(Ids, user);
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
                var result = await _productSvcs.CreateAlternateUnit(model, user);
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
            var result = await _productSvcs.GetAlternateUnits();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPut, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateAlternateUnit([FromQuery] Guid id, [FromBody] AlternateUnitModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _productSvcs.UpdateAlternateUnit(id, model, user);
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
        [HttpDelete, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveAlternateUnit([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _productSvcs.RemoveAlternateUnit(id, user);
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
            var result = await _productSvcs.GetRemovedAlternateUnits();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverAlternateUnit([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _productSvcs.RecoverAlternateUnit(id, user);
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
            var result = await _productSvcs.RecoverAllAlternateUnit(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete,  Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteAlternateUnit([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _productSvcs.DeleteAlternateUnit(id, user);
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
            var result = await _productSvcs.DeleteAllAlternateUnit(Ids, user);
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
                var result = await _productSvcs.CreateProductGroup(model, user);
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
            var result = await _productSvcs.GetProductGroups();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPut, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateProductGroup([FromQuery] Guid id, [FromBody] ProductGroupModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _productSvcs.UpdateProductGroup(id, model, user);
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
        [HttpDelete, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveProductGroup([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _productSvcs.RemoveProductGroup(id, user);
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
            var result = await _productSvcs.GetRemovedProductGroup();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverProductGroup([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _productSvcs.RecoverProductGroup(id, user);
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
            var result = await _productSvcs.RecoverAllProductGroup(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteProductGroup([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _productSvcs.DeleteProductGroup(id, user);
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
            var result = await _productSvcs.DeleteAllProductGroup(Ids, user);
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
                var result = await _productSvcs.CreateProductSubGroup(model, user);
                return result.ResponseCode == 201 ? Created(nameof(CreateProductSubGroup), result) : BadRequest(result);
            }
            else
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any()).ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                return BadRequest(errors);
            }
        }
        [HttpGet,Authorize]
        public async Task<IActionResult> GetProductSubGroups(Guid GroupId)
        {
            var result = await _productSvcs.GetProductSubGroups(GroupId);
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPut,  Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateProductSubGroup([FromQuery] Guid id, [FromBody] ProductSubGroupModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _productSvcs.UpdateProductSubGroup(id, model, user);
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
        [HttpDelete,Authorize(Roles = "Devloper,Admin"),  Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveProductSubGroup([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _productSvcs.RemoveProductSubGroup(id, user);
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
            var result = await _productSvcs.GetRemovedProductSubGroup();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch,  Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverProductSubGroup([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _productSvcs.RecoverProductSubGroup(id, user);
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
            var result = await _productSvcs.RecoverAllProductSubGroup(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteProductSubGroup([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _productSvcs.DeleteProductSubGroup(id, user);
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
            var result = await _productSvcs.DeleteAllProductSubGroup(Ids, user);
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
                var result = await _productSvcs.CreateProduct(model, user);
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
            var result = await _productSvcs.GetAllProducts();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPut, Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> UpdateProduct([FromQuery] Guid id, [FromBody] ProductModel model)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _productSvcs.UpdateProduct(id, model, user);
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
        [HttpDelete,  Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> RemoveProduct([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _productSvcs.RemoveProduct(id, user);
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
            var result = await _productSvcs.GetRemovedProduct();
            return result.ResponseCode == 200 ? Ok(result) : BadRequest(result);
        }
        [HttpPatch,  Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Update")]
        public async Task<IActionResult> RecoverProduct([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(User);
                    var result = await _productSvcs.RecoverProduct(id, user);
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
            var result = await _productSvcs.RecoverAllProduct(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        [HttpDelete,  Authorize(Roles = "Devloper,Admin"), Authorize(policy: "Delete")]
        public async Task<IActionResult> DeleteProduct([FromQuery] Guid id)
        {
            if (id != Guid.Empty)
            {
                var user = await _userManager.GetUserAsync(User);
                var result = await _productSvcs.DeleteProduct(id, user);
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
            var result = await _productSvcs.DeleteAllProduct(Ids, user);
            return result.ResponseCode == 200 ? Ok(result) : (result.ResponseCode == 404 ? NotFound(result) : BadRequest(result));
        }
        #endregion
        #endregion
    }
}


