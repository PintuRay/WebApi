using FMS.Db.Entity;
using FMS.Repo.Common;
using FMS.Svcs.CommonSvcs;
using FMS.Svcs.Email;

namespace FMS.Svcs.Common
{
    public  class CommonSvcs(ICommonRepo commonRepo,IEmailSvcs emailSvc) :ICommonSvcs
    {
        #region Dependancy
        private readonly ICommonRepo _commonRepo = commonRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Country
        #region Crud
        //public async Task<SvcsBase> GetCountries()
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.GetCountries();
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetCountries", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> CreateCountry(CountryModel data, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.CreateCountry(data, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Country Created Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Created,
        //            },
        //            false => new()
        //            {
        //                Message = $"Country '{data.CountryName}' Already Exist",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateCountry", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> UpdateCountry(Guid Id, CountryModel data, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.UpdateCountry(Id, data, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Country Updated Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"CountryId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateCountry", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RemoveCountry(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.RemoveCountry(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Country Removed Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"CountryId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveCountry", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        #endregion
        #region Recover
        //public async Task<SvcsBase> GetRemovedCountries()
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.GetRemovedCountries();
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedCountries", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RecoverCountry(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.RecoverCountry(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Country Recovered Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"CountryId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverCountry", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> DeleteCountry(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.DeleteCountry(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Country Deleted Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"CountryId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteCountry", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RecoverAllCountry(List<string> Ids, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.RecoverAllCountry(Ids, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Countries Recovered Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "Failed To Recover Countries",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllCountry", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> DeleteAllCountry(List<string> Ids, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.DeleteAllCountry(Ids, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Country Deleted Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "Failed To Delete Country",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllCountry", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        #endregion
        #endregion
        #region State
        #region Crud
        //public async Task<SvcsBase> GetStates(Guid CountryId)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.GetStates(CountryId);
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetStates", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> CreateState(StateModel data, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.CreateState(data, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "State Created Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Created,
        //            },
        //            false => new()
        //            {
        //                Message = $"State '{data.StateName}' Already Exist",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateState", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> UpdateState(Guid Id, StateModel data, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.UpdateState(Id, data, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "State Updated Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"StateId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateState", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RemoveState(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.RemoveState(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "State Removed Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"StateId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveState", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        #endregion
        #region Recover
        //public async Task<SvcsBase> GetRemovedStates()
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.GetRemovedStates();
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedStates", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RecoverState(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.RecoverState(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "State Recovered Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"StateId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverState", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> DeleteState(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.DeleteState(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "State Deleted Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"StateId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteState", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RecoverAllStates(List<string> Ids, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.RecoverAllStates(Ids, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "States Recovered Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "Failed To Recover States",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllStates", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> DeleteAllStates(List<string> Ids, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.DeleteAllStates(Ids, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "States Deleted Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "Failed To Delete States",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllStates", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        #endregion
        #endregion
        #region Dist
        #region Crud
        //public async Task<SvcsBase> GetDists(Guid Id)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.GetDists(Id);
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetDists", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> CreateDist(DistModel data, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.CreateDist(data, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Dist Created Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Created,
        //            },
        //            false => new()
        //            {
        //                Message = $"Dist '{data.DistName}' Already Exist",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateDist", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> UpdateDist(Guid Id, DistModel data, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.UpdateDist(Id, data, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Dist Updated Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"DistId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateDist", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RemoveDist(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.RemoveDist(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Dist Removed Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"DistId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveDist", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        #endregion
        #region Recover
        //public async Task<SvcsBase> GetRemovedDists()
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.GetRemovedDists();
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedDists", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RecoverDist(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.RecoverDist(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Dist Recovered Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"DistId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverDist", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> DeleteDist(Guid Id, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.DeleteDist(Id, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Dist Deleted Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = $"DistId '{Id}' Not Found",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteDist", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> RecoverAllDists(List<string> Ids, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.RecoverAllDist(Ids, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Dists Recovered Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "Failed To Recover Dists",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllDists", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        //public async Task<SvcsBase> DeleteAllDists(List<string> Ids, AppUser user)
        //{
        //    SvcsBase Obj;
        //    try
        //    {
        //        var repoResult = await _commonRepo.DeleteAllDist(Ids, user);
        //        Obj = repoResult.IsSucess switch
        //        {
        //            true => new()
        //            {
        //                Data = repoResult,
        //                Message = "Dists Deleted Successfully",
        //                ResponseCode = (int)ResponseCode.Status.Ok,
        //            },
        //            false => new()
        //            {
        //                Message = "Failed To Delete Dists",
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
        //        await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllDists", _Exception.ToString());
        //    }
        //    return Obj;
        //}
        #endregion
        #endregion
    }
}
