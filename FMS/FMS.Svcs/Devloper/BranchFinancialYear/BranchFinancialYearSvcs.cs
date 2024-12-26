using FMS.Db.Entity;
using FMS.Model;
using FMS.Repo.Devloper.BranchFinancialYear;
using FMS.Svcs.Email;

namespace FMS.Svcs.Devloper.BranchFinancialYear
{
    public class BranchFinancialYearSvcs(IBranchFinancialYearRepo branchFinancialYearRepo, IEmailSvcs emailSvc) : IBranchFinancialYearSvcs
    {
        #region Dependancy
        private readonly IBranchFinancialYearRepo _branchFinancialYearRepo = branchFinancialYearRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Branch Financial Year
        #region Crud
        //public async Task<SvcsBase> GetBranchFinancialYears(PaginationParams pagination)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _branchFinancialYearRepo.GetBranchFinancialYears(pagination);
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetBranchFinancialYears", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> GetBranchFinancialYears(Guid BranchId, PaginationParams pagination)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _branchFinancialYearRepo.GetBranchFinancialYears(BranchId, pagination);
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetBranchFinancialYears", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> CreateBranchFinancialYear(BranchFinancialYearModel data, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _branchFinancialYearRepo.CreateBranchFinancialYear(data, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Branch FinancialYear Created Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Created,
        //            },
        //            false => new()
        //            {
        //                Message = $"Branch FinancialYear Already Exist",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateBranchFinancialYear", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> UpdateBranchFinancialYear(Guid Id, BranchFinancialYearModel data, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _branchFinancialYearRepo.UpdateBranchFinancialYear(Id, data, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Branch FinancialYear Updated Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"BranchFinancialYearId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateBranchFinancialYear", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RemoveBranchFinancialYear(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _branchFinancialYearRepo.RemoveBranchFinancialYear(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Branch FinancialYear Removed Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"BranchFinancialYearId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveBranchFinancialYear", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        #endregion
        #region Recover
        //public async Task<SvcsBase> GetRemovedBranchFinancialYears(PaginationParams pagination)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _branchFinancialYearRepo.GetRemovedBranchFinancialYears(pagination);
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedBranchFinancialYears", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RecoverBranchFinancialYear(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _branchFinancialYearRepo.RecoverBranchFinancialYear(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Branch FinancialYear Recovered Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"BranchFinancialYearId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverBranchFinancialYear", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> DeleteBranchFinancialYear(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _branchFinancialYearRepo.DeleteBranchFinancialYear(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Branch Financial Year Deleted Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"BranchFinancialYearId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteBranchFinancialYear", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RecoverAllBranchFinancialYear(List<string> Ids, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _branchFinancialYearRepo.RecoverAllBranchFinancialYear(Ids, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Branch FinancialYears Recovered Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "Failed To Recover Branch FinancialYears",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllBranchFinancialYear", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> DeleteAllBranchFinancialYear(List<string> Ids, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _branchFinancialYearRepo.DeleteAllBranchFinancialYear(Ids, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Branch FinancialYears Deleted Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "Failed To Delete Branch Financial Years",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllBranchFinancialYear", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        #endregion
        #endregion
    }
}
