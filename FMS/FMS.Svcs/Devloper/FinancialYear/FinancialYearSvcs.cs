using FMS.Db.Entity;
using FMS.Model;
using FMS.Repo.Devloper.FinancialYear;
using FMS.Svcs.Email;

namespace FMS.Svcs.Devloper.FinancialYear
{
    public class FinancialYearSvcs(IFinancialYearRepo financialYearRepo, FinancialYearValidator financialYearValidator, IEmailSvcs emailSvc) : IFinancialYearSvcs
    {
        #region Dependancy
        private readonly IFinancialYearRepo _financialYearRepo = financialYearRepo;
        private readonly FinancialYearValidator _financialYearValidator = financialYearValidator;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Financial Year
        #region Crud
        public async Task<SvcsBase> GetFinancialYears(Guid BranchId)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _financialYearRepo.GetFinancialYears(BranchId);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetFinancialYears", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> GetFinancialYears(PaginationParams pagination)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _financialYearRepo.GetFinancialYears(pagination);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetFinancialYears", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateFinancialYear(FinancialYearModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationResult = await _financialYearValidator.ValidateAsync(data);
                if (validationResult.IsValid)
                {
                    var repoResult = await _financialYearRepo.CreateFinancialYear(data, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Financial Year Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Created,
                        },
                        false => new()
                        {
                            Message = $"Financial Year {data.Financial_Year} Already Exist",
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                        },
                    };
                }
                else
                {
                    Obj = new()
                    {
                        Data = validationResult.Errors.ToArray(),
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    };
                }

            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "CreateFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkCreateFinancialYear(List<FinancialYearModel> dataList, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationTasks = dataList.Select(b => _financialYearValidator.ValidateAsync(b));
                var validationResults = await Task.WhenAll(validationTasks);
                if (validationResults.All(r => r.IsValid))
                {
                    var repoResult = await _financialYearRepo.BulkCreateFinancialYear(dataList, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "financial Years Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Created,
                        },
                        false => new()
                        {
                            Message = $"Following Financial years '{string.Join(", ", repoResult.Records)}' Already Exist",
                            ResponseCode = (int)ResponseCode.Status.BadRequest,
                        },
                    };
                }
                else
                {
                    Obj = new()
                    {
                        Data = validationResults.SelectMany(r => r.Errors).ToArray(),
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkCreateFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateFinancialYear(FinancialYearUpdateModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationResult = await _financialYearValidator.ValidateAsync(data);
                if (validationResult.IsValid)
                {
                    var repoResult = await _financialYearRepo.UpdateFinancialYear(data, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Financial Year Updated Successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        },
                        false => new()
                        {
                            Message = $"Financial Year '{data.FinancialYearId}' Not Found",
                            ResponseCode = (int)ResponseCode.Status.NotFound,
                        },
                    };
                }
                else
                {
                    Obj = new()
                    {
                        Data = validationResult.Errors.ToArray(),
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "UpdateFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkUpdateFinancialYear(List<FinancialYearUpdateModel> dataList, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationTasks = dataList.Select(b => _financialYearValidator.ValidateAsync(b));
                var validationResults = await Task.WhenAll(validationTasks);
                if (validationResults.All(r => r.IsValid))
                {
                    var repoResult = await _financialYearRepo.BulkUpdateFinancialYear(dataList, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Financial years Updated Successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        },
                        false => new()
                        {
                            Message = $"Following BranchIds '{string.Join(", ", repoResult.Ids)}' Not Found",
                            ResponseCode = (int)ResponseCode.Status.NotFound,
                        },
                    };
                }
                else
                {
                    Obj = new()
                    {
                        Data = validationResults.SelectMany(r => r.Errors).ToArray(),
                        ResponseCode = (int)ResponseCode.Status.BadRequest,
                    };
                }
            }
            catch (Exception _Exception)
            {
                Obj = new()
                {
                    Message = _Exception.Message,
                    ResponseCode = (int)ResponseCode.Status.BadRequest,
                };
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkUpdateFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveFinancialYear(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _financialYearRepo.RemoveFinancialYear(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Financial Year Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"FinancialYear Id '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RemoveFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkRemoveFinancialYear(List<FinancialYearUpdateModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _financialYearRepo.BulkRecoverFinancialYear(listdata, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Financial Years Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"Following Financial Years  '{string.Join(", ", repoResult.Ids)}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkRemoveFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedFinancialYears(PaginationParams pagination)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _financialYearRepo.GetRemovedFinancialYears(pagination);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No Record Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetRemovedFinancialYears", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverFinancialYear(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _financialYearRepo.RecoverFinancialYear(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Financial Year Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"FinancialYear Id '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RecoverFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteFinancialYear(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _financialYearRepo.DeleteFinancialYear(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Financial Year Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Financial Year",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkRecoverFinancialYear(List<FinancialYearUpdateModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _financialYearRepo.BulkRecoverFinancialYear(listdata, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Financial Years Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Financial Years",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RecoverAllFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkDeleteFinancialYear(List<Guid> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _financialYearRepo.BulkDeleteFinancialYear(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Financial Years Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Financial Years",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteAllFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
    }
}
