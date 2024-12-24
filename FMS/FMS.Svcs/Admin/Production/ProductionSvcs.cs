using FMS.Db.Entity;
using FMS.Repo.Admin.Product;
using FMS.Repo.Admin.Production;
using FMS.Svcs.Email;

namespace FMS.Svcs.Admin.Production
{
    public class ProductionSvcs(IProductionRepo productionRepo, IEmailSvcs emailSvc) : IProductionSvcs
    {
        #region Dependancy
        private readonly IProductionRepo _productionRepo = productionRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Production 
        #region Crud
        public async Task<SvcsBase> GetProduction()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productionRepo.GetProduction();
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetProduction", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateProduction(ProductionOrderModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productionRepo.CreateProduction(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Production Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        Message = $"Production Record Already Exist",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateProduction", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateProduction(Guid Id, ProductionOrderModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productionRepo.UpdateProduction(Id, data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Production Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"ProductionId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateProduction", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveProduction(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productionRepo.RemoveProduction(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Production Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"ProductionId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveProduction", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedProduction()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productionRepo.GetRemovedProduction();
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedProduction", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverProduction(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productionRepo.RecoverProduction(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Production Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"ProductionId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverProduction", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteProduction(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productionRepo.DeleteProduction(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Production Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"ProductionId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteProduction", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllProduction(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productionRepo.RecoverAllProduction(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Productions Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Productions",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllProduction", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllProduction(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _productionRepo.DeleteAllProduction(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Productions Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Productions",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllProduction", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
    }
}
