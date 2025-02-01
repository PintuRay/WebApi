using FMS.Db.Entity;
using FMS.Model;
using FMS.Repo.Devloper.BranchFinancialYear;
using FMS.Svcs.Email;

namespace FMS.Svcs.Devloper.BranchFinancialYear
{
    public class BranchFinancialYearSvcs(IBranchFinancialYearRepo branchFinancialYearRepo, BranchFinancialYearValidator branchFinancialYearValidator, IEmailSvcs emailSvc) : IBranchFinancialYearSvcs
    {
        #region Dependancy
        private readonly IBranchFinancialYearRepo _branchFinancialYearRepo = branchFinancialYearRepo;
        private readonly BranchFinancialYearValidator _branchFinancialYearValidator = branchFinancialYearValidator;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Branch Financial Year
        #region Crud
        public async Task<SvcsBase> GetBranchFinancialYears()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchFinancialYearRepo.GetBranchFinancialYears();
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetBranchFinancialYears", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> GetBranchFinancialYears(Guid BranchId)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchFinancialYearRepo.GetBranchFinancialYears(BranchId);
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetBranchFinancialYears", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> GetBranchFinancialYears(PaginationParams pagination)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchFinancialYearRepo.GetBranchFinancialYears(pagination);
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetBranchFinancialYears", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateBranchFinancialYear(BranchFinancialYearModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationResult = await _branchFinancialYearValidator.ValidateAsync(data);
                if (validationResult.IsValid)
                {
                    var repoResult = await _branchFinancialYearRepo.CreateBranchFinancialYear(data, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Branch FinancialYear Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Created,
                        },
                        false => new()
                        {
                            Message = $"Branch FinancialYear Already Exist",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "CreateBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkCreateBranchFinancialYear(List<BranchFinancialYearModel> dataList, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationTasks = dataList.Select(b => _branchFinancialYearValidator.ValidateAsync(b));
                var validationResults = await Task.WhenAll(validationTasks);
                if (validationResults.All(r => r.IsValid))
                {
                    var repoResult = await _branchFinancialYearRepo.BulkCreateBranchFinancialYear(dataList, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "branch financial Years Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Created,
                        },
                        false => new()
                        {
                            Message = $"Following Branch Financial years '{string.Join(", ", repoResult.Records)}' Already Exist",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkCreateBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateBranchFinancialYear(BranchFinancialYearUpdateModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationResult = await _branchFinancialYearValidator.ValidateAsync(data);
                if (validationResult.IsValid)
                {
                    var repoResult = await _branchFinancialYearRepo.UpdateBranchFinancialYear(data, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Branch FinancialYear Updated Successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        },
                        false => new()
                        {
                            Message = $"BranchFinancialYearId '{data.BranchFinancialYearId}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "UpdateBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkUpdateBranchFinancialYear(List<BranchFinancialYearUpdateModel> dataList, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationTasks = dataList.Select(b => _branchFinancialYearValidator.ValidateAsync(b));
                var validationResults = await Task.WhenAll(validationTasks);
                if (validationResults.All(r => r.IsValid))
                {
                    var repoResult = await _branchFinancialYearRepo.BulkUpdateBranchFinancialYear(dataList, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Branch Financial years Updated Successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        },
                        false => new()
                        {
                            Message = $"Following BranchfinancialyearIds '{string.Join(", ", repoResult.Ids)}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkUpdateBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveBranchFinancialYear(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchFinancialYearRepo.RemoveBranchFinancialYear(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Branch FinancialYear Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchFinancialYearId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RemoveBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkRemoveBranchFinancialYear(List<Guid> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchFinancialYearRepo.BulkRemoveBranchFinancialYear(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Branch Financial Years Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"Following Branch Financial Years  '{string.Join(", ", repoResult.Ids)}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkRemoveBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedBranchFinancialYears(PaginationParams pagination)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchFinancialYearRepo.GetRemovedBranchFinancialYears(pagination);
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetRemovedBranchFinancialYears", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverBranchFinancialYear(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchFinancialYearRepo.RecoverBranchFinancialYear(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Branch FinancialYear Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchFinancialYearId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RecoverBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteBranchFinancialYear(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchFinancialYearRepo.DeleteBranchFinancialYear(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Branch Financial Year Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchFinancialYearId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkRecoverBranchFinancialYear(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchFinancialYearRepo.BulkRecoverBranchFinancialYear(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Branch FinancialYears Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Branch FinancialYears",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RecoverAllBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkDeleteBranchFinancialYear(List<string> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchFinancialYearRepo.BulkDeleteBranchFinancialYear(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Branch FinancialYears Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Delete Branch Financial Years",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteAllBranchFinancialYear", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
    }
}
