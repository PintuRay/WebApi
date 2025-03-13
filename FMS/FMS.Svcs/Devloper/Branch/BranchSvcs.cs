using AutoMapper;
using FMS.Db.Entity;
using FMS.Model;
using FMS.Repo;
using FMS.Repo.Devloper.Branch;
using FMS.Svcs.Common.Address;
using FMS.Svcs.Email;
using System.Collections.Generic;

namespace FMS.Svcs.Devloper.Branch
{
    public class BranchSvcs(IBranchRepo branchRepo, IAddressSvcs _addressSvcs, IMapper mapper, BranchValidator branchValidator, BranchUpdateValidator branchUpdateValidator, IEmailSvcs emailSvc) : IBranchSvcs
    {
        #region Dependancy
        private readonly IBranchRepo _branchRepo = branchRepo;
        private readonly IAddressSvcs _addressSvcs = _addressSvcs;
        private readonly BranchValidator _branchValidator = branchValidator;
        private readonly BranchUpdateValidator _branchUpdateValidator = branchUpdateValidator;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        private readonly IMapper _mapper = mapper;
        #endregion
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
                        Data = repoResult.Records,
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
                        Data = repoResult.Records,
                        Count = repoResult.Count,
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
                    var AddressResult = await _addressSvcs.CreateAdress(data.Address);
                    if (AddressResult.ResponseCode == 201)
                    {
                        data.Fk_AdressId = ((Address)AddressResult.Data).AddressId;
                        var branchResult = await _branchRepo.CreateBranch(data, user);
                        Obj = branchResult.IsSucess switch
                        {
                            true => new()
                            {
                                Data = branchResult.Records,
                                Message = "Branch Created Successfully",
                                ResponseCode = (int)ResponseCode.Status.Created,
                            },
                            false => new()
                            {
                                Message = $"Branch '{data.BranchName}' Already Exist",
                                ResponseCode = (int)ResponseCode.Status.Found,
                            },
                        };
                    }
                    else
                    {
                        Obj = new()
                        {
                            Data = AddressResult.Data,
                            Message = AddressResult.Message,
                            ResponseCode = AddressResult.ResponseCode,
                        };
                    }
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
                    var addresses = listdata.Select(s => s.Address).ToList();
                    var svcsResult = await _addressSvcs.BulkCreateAdress(addresses);
                    if (svcsResult.ResponseCode == 201)
                    {
                        if (svcsResult.Data is List<Db.Entity.Address> createdAddresses)
                        {
                            for (int i = 0; i < listdata.Count; i++)
                            {
                                if (i < createdAddresses.Count)
                                {
                                    listdata[i].Fk_AdressId = createdAddresses[i].AddressId;
                                    listdata[i].Address = _mapper.Map<AddressModel>(createdAddresses[i]);
                                }
                            }
                            var repoResult = await _branchRepo.BulkCreateBranch(listdata, user);
                            Obj = repoResult.IsSucess switch
                            {
                                true => new()
                                {
                                    Data = repoResult.Records,
                                    Message = "Branches Created Successfully",
                                    ResponseCode = (int)ResponseCode.Status.Created,
                                },
                                false => new()
                                {
                                    Data = repoResult.Records,
                                    Message = repoResult.ResponseCode == 400 ? repoResult.Message : "Branch already exist",
                                    ResponseCode = repoResult.ResponseCode == 400 ? (int)ResponseCode.Status.BadRequest : (int)ResponseCode.Status.Found,
                                },
                            };
                        }
                        else
                        {
                            Obj = new()
                            {
                                Message = "Failed to process created addresses",
                                ResponseCode = (int)ResponseCode.Status.BadRequest,
                            };
                        }
                    }
                    else
                    {
                        Obj = new()
                        {
                            Data = svcsResult.Data,
                            Message = svcsResult.Message,
                            ResponseCode = svcsResult.ResponseCode,
                        };
                    }
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkCreateBranch", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateBranch(BranchUpdateModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationResult = await _branchUpdateValidator.ValidateAsync(data);
                if (validationResult.IsValid)
                {
                    var svcsResult = await _addressSvcs.UpdateAdress(data.Address);
                    if (svcsResult.ResponseCode == 200)
                    {
                        var repoResult = await _branchRepo.UpdateBranch(data, user);
                        Obj = repoResult.IsSucess switch
                        {
                            true => new()
                            {
                                Data = repoResult.Records,
                                Message = "Branch updated successfully",
                                ResponseCode = (int)ResponseCode.Status.Ok,
                            },
                            false => new()
                            {
                                Message = $"BranchId '{data.BranchId}' not found",
                                ResponseCode = (int)ResponseCode.Status.NotFound,
                            },
                        };
                    }
                    else
                    {
                        Obj = new()
                        {
                            Data = svcsResult.Data,
                            Message = svcsResult.Message,
                            ResponseCode = svcsResult.ResponseCode,
                        };
                    }
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
                var validationTasks = listdata.Select(b => _branchUpdateValidator.ValidateAsync(b));
                var validationResults = await Task.WhenAll(validationTasks);
                if (validationResults.All(r => r.IsValid))
                {
                    var addresses = listdata.Select(s => s.Address).ToList();
                    var svcsResult = await _addressSvcs.BulkUpdateAdress(addresses);
                    if (svcsResult.ResponseCode == 200)
                    {
                        var repoResult = await _branchRepo.BulkUpdateBranch(listdata, user);
                        Obj = repoResult.IsSucess switch
                        {
                            true => new()
                            {
                                Data = repoResult.Records,
                                Message = "Branches Updated Successfully",
                                ResponseCode = (int)ResponseCode.Status.Ok,
                            },
                            false => new()
                            {
                                Data = repoResult.Records,
                                Message = repoResult.ResponseCode == 400 ? repoResult.Message : $"Some records not found",
                                ResponseCode = repoResult.ResponseCode == 400 ? (int)ResponseCode.Status.BadRequest : (int)ResponseCode.Status.NotFound,
                            },
                        };
                    }
                    else
                    {
                        Obj = new()
                        {
                            Data = svcsResult.Data,
                            Message = svcsResult.Message,
                            ResponseCode = svcsResult.ResponseCode,
                        };
                    }
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkUpdateBranch", _Exception.ToString());
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
                        Data = repoResult.Records,
                        Message = "Branch removed successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"BranchId '{Id}' not found",
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
        public async Task<SvcsBase> BulkRemoveBranch(List<BranchUpdateModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchRepo.BulkRemoveBranch(listdata, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.Records,
                        Message = $"{((List<BranchDto>)repoResult.Records).Count} removed, {listdata.Count - ((List<BranchDto>)repoResult.Records).Count} failed",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"Failed to  remove branch",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkRemoveBranch", _Exception.ToString());
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
                        Data = repoResult.Records,
                        Count = repoResult.Count,
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "No record exist",
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
                        Data = repoResult.Records,
                        Message = "Branch recovered successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Data = repoResult.Records,
                        Message = repoResult.ResponseCode == 302 ? $"Unable to recover due to an  active record found" : $"BranchId '{Id}' not found",
                        ResponseCode = repoResult.ResponseCode == 302 ? (int)ResponseCode.Status.Found : (int)ResponseCode.Status.NotFound,
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
        public async Task<SvcsBase> BulkRecoverBranch(List<BranchUpdateModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _branchRepo.BulkRecoverBranch(listdata, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.Records,
                        Message = $"{((List<BranchDto>)repoResult.Records).Count} removed, {listdata.Count - ((List<BranchDto>)repoResult.Records).Count} failed",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed to recover branch",
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
                        Data = repoResult.Id,
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
                        Data = repoResult.Ids,
                        Message = $"{repoResult.Ids.Count} deleted, {Ids.Count - repoResult.Ids.Count} failed",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To delete branch",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteAllBranch", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
    }
}
