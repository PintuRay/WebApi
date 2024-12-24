using FMS.Db.Entity;
using FMS.Repo.Admin.Product;
using FMS.Svcs.Email;

namespace FMS.Svcs.Admin.Product
{
    public class ProductSvcs(IProductRepo productRepo, IEmailSvcs emailSvc) : IProductSvcs
    {
        #region Dependancy
        private readonly IProductRepo _productRepo = productRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Product 
        #region Product Type
        public async Task<SvcsBase> GetProductTypes()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.GetProductTypes();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Exist",
                        ResponseCode = (int)ResponseCode.Status.NoContent,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetProductTypes", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Unit
        #region Crud
        public async Task<SvcsBase> GetAllUnits()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.GetAllUnits();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Exist",
                        ResponseCode = (int)ResponseCode.Status.NoContent,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetAllUnits", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateUnit(UnitModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.CreateUnit(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Unit Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        Message = $"Unit '{data.UnitName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateUnit(Guid Id, UnitModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.UpdateUnit(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Unit Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"UnitId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveUnit(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.RemoveUnit(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Unit Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"UnitId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveUnit", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedUnits()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.GetRemovedUnits();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Exist",
                        ResponseCode = (int)ResponseCode.Status.NoContent,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedUnits", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverUnit(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.RecoverUnit(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Unit Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"UnitId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteUnit(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.DeleteUnit(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Unit Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"UnitId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllUnit(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.RecoverAllUnit(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Units Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Units",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllUnit(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.DeleteAllUnit(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Units Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Units",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllUnit", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Alternate Unit
        #region Crud
        public async Task<SvcsBase> GetAlternateUnits()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.GetAlternateUnits();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Exist",
                        ResponseCode = (int)ResponseCode.Status.NoContent,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetAlternateUnits", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateAlternateUnit(AlternateUnitModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.CreateAlternateUnit(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "AlternateUnit Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        Message = $"AlternateUnit '{data.AlternateUnitName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateAlternateUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateAlternateUnit(Guid Id, AlternateUnitModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.UpdateAlternateUnit(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "AlternateUnit Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"AlternateUnitId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateAlternateUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveAlternateUnit(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.RemoveAlternateUnit(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "AlternateUnit Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"AlternateUnitId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveAlternateUnit", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedAlternateUnits()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.GetRemovedAlternateUnits();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Exist",
                        ResponseCode = (int)ResponseCode.Status.NoContent,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedAlternateUnits", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAlternateUnit(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.RecoverAlternateUnit(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "AlternateUnit Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"AlternateUnitId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAlternateUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAlternateUnit(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.DeleteAlternateUnit(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "AlternateUnit Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"AlternateUnitId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAlternateUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllAlternateUnit(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.RecoverAllAlternateUnit(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "AlternateUnits Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover AlternateUnits",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllAlternateUnit", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllAlternateUnit(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.DeleteAllAlternateUnit(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "AlternateUnits Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete AlternateUnits",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllAlternateUnit", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Product Group
        #region Crud
        public async Task<SvcsBase> GetProductGroups()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.GetProductGroups();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Exist",
                        ResponseCode = (int)ResponseCode.Status.NoContent,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetProductGroups", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateProductGroup(ProductGroupModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.CreateProductGroup(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.Id,
                        Message = "ProductGroup Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        Message = $"ProductGroup '{data.ProductGroupName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateProductGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateProductGroup(Guid Id, ProductGroupModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.UpdateProductGroup(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "ProductGroup Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"ProductGroupId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateProductGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveProductGroup(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.RemoveProductGroup(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "ProductGroup Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"ProductGroupId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveProductGroup", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedProductGroup()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.GetRemovedProductGroup();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Exist",
                        ResponseCode = (int)ResponseCode.Status.NoContent,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedProductGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverProductGroup(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.RecoverProductGroup(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "ProductGroup Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"ProductGroupId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverProductGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteProductGroup(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.DeleteProductGroup(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "ProductGroup Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"ProductGroupId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteProductGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllProductGroup(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.RecoverAllProductGroup(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "ProductGroups Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover ProductGroups",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllProductGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllProductGroup(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.DeleteAllProductGroup(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "ProductGroups Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete ProductGroups",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllProductGroup", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Product SubGroup
        #region Crud
        public async Task<SvcsBase> GetProductSubGroups(Guid GroupId)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.GetProductSubGroups(GroupId);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Exist",
                        ResponseCode = (int)ResponseCode.Status.NoContent,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetProductSubGroups", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateProductSubGroup(ProductSubGroupModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.CreateProductSubGroup(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "ProductSubGroup Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        Message = $"ProductSubGroup '{data.ProductSubGroupName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateProductSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateProductSubGroup(Guid Id, ProductSubGroupModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.UpdateProductSubGroup(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "ProductSubGroup Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"ProductSubGroupId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateProductSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveProductSubGroup(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.RemoveProductSubGroup(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "ProductSubGroup Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"ProductSubGroupId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveProductSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedProductSubGroup()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.GetRemovedProductSubGroup();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Exist",
                        ResponseCode = (int)ResponseCode.Status.NoContent,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedProductSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverProductSubGroup(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.RecoverProductSubGroup(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "ProductSubGroup Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"ProductSubGroupId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverProductSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteProductSubGroup(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.DeleteProductSubGroup(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "ProductSubGroup Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"ProductSubGroupId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteProductSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllProductSubGroup(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.RecoverAllProductSubGroup(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "ProductSubGroups Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover ProductSubGroups",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllProductSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllProductSubGroup(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.DeleteAllProductSubGroup(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "ProductSubGroups Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete ProductSubGroups",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllProductSubGroup", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #region Product
        #region Crud
        public async Task<SvcsBase> GetAllProducts()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.GetAllProducts();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Exist",
                        ResponseCode = (int)ResponseCode.Status.NoContent,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetAllProducts", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateProduct(ProductModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.CreateProduct(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.Id,
                        Message = "Product Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        Message = $"Product '{data.ProductName}' Already Exist",
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateProduct", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateProduct(Guid Id, ProductModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.UpdateProduct(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Product Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"ProductId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateProduct", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveProduct(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.RemoveProduct(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Product Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"ProductId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveProduct", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedProduct()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.GetRemovedProduct();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Exist",
                        ResponseCode = (int)ResponseCode.Status.NoContent,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedProduct", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverProduct(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.RecoverProduct(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Product Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"ProductId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverProduct", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteProduct(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.DeleteProduct(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Product Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"ProductId '{Id}' Not Found",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteProduct", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllProduct(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.RecoverAllProduct(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Products Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Products",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllProduct", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllProduct(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productRepo.DeleteAllProduct(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Products Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Products",
                        ResponseCode = (int)ResponseCode.Status.NotFound,
                    },
                };
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllProduct", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
        #endregion
    }
}
