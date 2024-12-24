using FMS.Db.Entity;
using FMS.Repo.Admin.Company;
using FMS.Svcs.Email;

namespace FMS.Svcs.Admin.Company
{
    public class CompanySvcs(ICompanyRepo companyRepo, IEmailSvcs emailSvc) : ICompanySvcs
    {
        #region Dependancy
        private readonly ICompanyRepo _companyRepo = companyRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Company
        #region Crud
        public async Task<SvcsBase> GetCompany(string BranchId)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _companyRepo.GetCompany(BranchId);
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetCompany", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateCompany(CompanyModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _companyRepo.CreateCompany(data, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Company Created Successfully",
                        ResponseCode = (int)ResponseCode.Status.Created,
                    },
                    false => new()
                    {
                        Message = $"Company '{data.CompanyName}' Already Exist",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "CreateCompany", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateCompany(Guid Id, CompanyModel model, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _companyRepo.UpdateCompany(Id, model, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Company Updated Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"CompanyId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "UpdateCompany", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveCompany(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _companyRepo.RemoveCompany(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Company Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"CompanyId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RemoveCompany", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedCompanies(string BranchId)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _companyRepo.GetRemovedCompanies(BranchId);
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "GetRemovedCompanies", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverCompany(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _companyRepo.RecoverCompany(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Company Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"CompanyId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverCompany", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteCompany(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _companyRepo.DeleteCompany(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Company Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"CompanyId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteCompany", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverAllCompany(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _companyRepo.RecoverAllCompany(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Companies Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Companies",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "RecoverAllCompany", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteAllCompany(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _companyRepo.DeleteAllCompany(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Companies Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Companies",
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
                await _emailSvcs.SendExceptionEmail("exception@gmail.com", "DeleteAllCompany", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
    }
}
