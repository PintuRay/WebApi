using FMS.Db.Entity;
using FMS.Repo.Admin.LabourRate;
using FMS.Svcs.Email;

namespace FMS.Svcs.Admin.LabourRate
{
    public class LabourRateSvcs(ILabourRateRepo labourRateRepo, IEmailSvcs emailSvc) : ILabourRateSvcs
    {
        #region Dependancy
        private readonly ILabourRateRepo _labourRateRepo = labourRateRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Labour Rate 
        #region Crud
        //public async Task<SvcsBase> GetAllLabourRates(Guid FinancialYearId, Guid BranchId)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _labourRateRepo.GetAllLabourRates(FinancialYearId, BranchId);
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
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetAllLabourRates", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> CreateLabourRate(LabourRateModel data, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _labourRateRepo.CreateLabourRate(data, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "LabourRate Created Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Created,
        //            },
        //            false => new()
        //            {
        //                Message = $"LabourRate Already Exist",
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
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "CreateLabourRate", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> UpdateLabourRate(Guid Id, LabourRateModel data, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _labourRateRepo.UpdateLabourRate(Id, data, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "LabourRate Updated Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"LabourRateId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "UpdateLabourRate", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RemoveLabourRate(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _labourRateRepo.RemoveLabourRate(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "LabourRate Removed Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"LabourRateId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RemoveLabourRate", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        #endregion
        #region Recover
        //public async Task<SvcsBase> GetRemovedLabourRate(Guid FinancialYearId, Guid BranchId)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _labourRateRepo.GetRemovedLabourRate(FinancialYearId, BranchId);
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
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetRemovedLabourRate", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RecoverLabourRate(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _labourRateRepo.RecoverLabourRate(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "LabourRate Recovered Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"LabourRateId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RecoverLabourRate", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> DeleteLabourRate(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _labourRateRepo.DeleteLabourRate(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "LabourRate Deleted Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"LabourRateId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteLabourRate", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RecoverAllLabourRate(List<string> Ids, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _labourRateRepo.RecoverAllLabourRate(Ids, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "LabourRates Recovered Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "Failed To Recover LabourRates",
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
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RecoverAllLabourRate", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> DeleteAllLabourRate(List<string> Ids, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _labourRateRepo.DeleteAllLabourRate(Ids, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "LabourRates Deleted Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "Failed To Delete LabourRates",
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
        //        await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteAllLabourRate", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        #endregion
        #endregion
    }
}
