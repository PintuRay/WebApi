using FMS.Db.Entity;
using FMS.Repo.Admin.Sales;
using FMS.Svcs.Email;

namespace FMS.Svcs.Admin.Sales
{
    public class SalesSvcs(ISalesRepo salesRepo, IEmailSvcs emailSvc) : ISalesSvcs
    {
        #region Dependancy
        private readonly ISalesRepo _salesRepo = salesRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Sales   
        #region Crud
        //public async Task<SvcsBase> GetSales()
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _salesRepo.GetSales();
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "No Record Exist",
        //                ResponseCode = (int)ResponseCode.Status.NoContent,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", " GetSales", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> CreateSales(SalesOrderSetupModel requestData, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _salesRepo.CreateSales(requestData, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Sales Created Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Created,
        //            },
        //            false => new()
        //            {
        //                Message = $"Sales Already Exist",
        //                ResponseCode = (int)ResponseCode.Status.BadRequest,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateSales", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> UpdateSales(Guid Id, SalesOrderSetupModel data, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _salesRepo.UpdateSales(Id, data, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Sales Updated Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"SalesId '{Id}' Not Found",
        //                ResponseCode = (int)ResponseCode.Status.NotFound,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateSales", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RemoveSales(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _salesRepo.RemoveSales(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Sales Removed Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"SalesId '{Id}' Not Found",
        //                ResponseCode = (int)ResponseCode.Status.NotFound,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveSales", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        #endregion
        #region Recover
        //public async Task<SvcsBase> GetRemovedSales()
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _salesRepo.GetRemovedSales();
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "No Record Exist",
        //                ResponseCode = (int)ResponseCode.Status.NoContent,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedSales", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RecoverSales(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _salesRepo.RecoverSales(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Sales Recovered Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"SalesId '{Id}' Not Found",
        //                ResponseCode = (int)ResponseCode.Status.NotFound,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverSales", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> DeleteSales(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _salesRepo.DeleteSales(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Sales Deleted Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"SalesId '{Id}' Not Found",
        //                ResponseCode = (int)ResponseCode.Status.NotFound,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteSales", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RecoverAllSales(List<string> Ids, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _salesRepo.RecoverAllSales(Ids, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Sales Recovered Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "Failed To Recover Sales",
        //                ResponseCode = (int)ResponseCode.Status.NotFound,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllSales", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> DeleteAllSales(List<string> Ids, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _salesRepo.DeleteAllSales(Ids, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Sales Deleted Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "Failed To Delete Sales",
        //                ResponseCode = (int)ResponseCode.Status.NotFound,
        //            },
        //        };
        //    }
        //    catch (Exception _Exception)
        //    {
        //        Obj = new()
        //        {
        //            Message = _Exception.Message,
        //            ResponseCode = (int)ResponseCode.Status.BadRequest,
        //        };
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllSales", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        #endregion
        #endregion
    }
}
