using FluentValidation.Results;
using FMS.Db.Entity;
using FMS.Model;
using FMS.Repo.Devloper.Branch;
using FMS.Svcs.Email;
using System.ComponentModel.DataAnnotations;

namespace FMS.Svcs.Devloper.Branch
{
    public class BranchSvcs(IBranchRepo branchRepo, BranchValidator branchValidator, IEmailSvcs emailSvc) : IBranchSvcs
    {
        #region Dependancy
        private readonly IBranchRepo _branchRepo = branchRepo;
        private readonly BranchValidator _branchValidator = branchValidator;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        #region Branch
        #region Crud
        public async Task<SvcsBase> GetAllBranch()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchRepo.GetAllBranch();
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message ="No Record Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetAllBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> GetAllBranch(PaginationParams pagination)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchRepo.GetAllBranch(pagination);
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetAllBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateBranch(BranchModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationResult = await _branchValidator.ValidateAsync(data);
                if (validationResult.IsValid)
                {
                    var repoResult = await _branchRepo.CreateBranch(data, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Branch Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Created,
                        },
                        false => new()
                        {
                            Message = $"Branch '{data.BranchName}' Already Exist",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "CreateBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkCreateBranch(List<BranchModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationTasks = listdata.Select(b => _branchValidator.ValidateAsync(b));
                var validationResults = await Task.WhenAll(validationTasks);
                if (validationResults.All(r => r.IsValid))
                {
                    var repoResult = await _branchRepo.BulkCreateBranch(listdata, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Branchs Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Created,
                        },
                        false => new()
                        {
                            Message = $"Following Branches '{string.Join(", ", repoResult.Records)}' Already Exist",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "CreateBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateBranch(BranchUpdateModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationResult = await _branchValidator.ValidateAsync(data);
                if (validationResult.IsValid)
                {
                    var repoResult = await _branchRepo.UpdateBranch(data, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Branch Updated Successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        },
                        false => new()
                        {
                            Message = $"BranchId '{data.BranchId}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "UpdateBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkUpdateBranch(List<BranchUpdateModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationTasks = listdata.Select(b => _branchValidator.ValidateAsync(b));
                var validationResults = await Task.WhenAll(validationTasks);
                if (validationResults.All(r => r.IsValid))
                {
                    var repoResult = await _branchRepo.BulkUpdateBranch(listdata, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Branches Updated Successfully",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "UpdateBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveBranch(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchRepo.RemoveBranch(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Branch Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RemoveBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkRemoveBranch(List<Guid> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchRepo.BulkRemoveBranch(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Branches Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"Following BranchIds '{string.Join(", ", repoResult.Ids)}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RemoveBranch", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedBranches(PaginationParams pagination)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchRepo.GetRemovedBranches(pagination);
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetRemovedBranches", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverBranch(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchRepo.RecoverBranch(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Branch Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RecoverBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkRecoverBranch(List<Guid> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchRepo.BulkRecoverBranch(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Branches Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"Following BranchIds '{string.Join(", ", repoResult.Ids)}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RecoverAllBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteBranch(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchRepo.DeleteBranch(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Branch Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkDeleteBranch(List<Guid> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchRepo.BulkDeleteBranch(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Branches Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"Following BranchIds '{string.Join(", ", repoResult.Ids)}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteAllBranch", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #endregion
    }
}
