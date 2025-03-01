using FMS.Db.Entity;
using FMS.Model;
using FMS.Repo.Admin.Dist;
using FMS.Svcs.Email;

namespace FMS.Svcs.Admin.Dist
{
    public class DistSvcs(IDistRepo distRepo, IEmailSvcs emailSvc, DistValidator distValidator, DistUpdateValidator distUpdateValidator) : IDistSvcs
    {
        #region Dependancy
        private readonly IDistRepo _distRepo = distRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        private readonly DistValidator _distValidator = distValidator;
        private readonly DistUpdateValidator _distUpdateValidator = distUpdateValidator;
        #endregion
        #region Crud
        public async Task<SvcsBase> GetDists(Guid Id)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _distRepo.GetDists(Id);
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetDists", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> GetDists(PaginationParams pagination)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _distRepo.GetDists(pagination);
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetDists", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateDist(DistModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationResult = await _distValidator.ValidateAsync(data);
                if (validationResult.IsValid)
                {
                    var repoResult = await _distRepo.CreateDist(data, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Dist Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Created,
                        },
                        false => new()
                        {
                            Message = $"Dist '{data.DistName}' Already Exist",
                            ResponseCode = (int)ResponseCode.Status.Found,
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "CreateDist", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkCreateDist(List<DistModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationTasks = listdata.Select(b => _distValidator.ValidateAsync(b));
                var validationResults = await Task.WhenAll(validationTasks);
                if (validationResults.All(r => r.IsValid))
                {
                    var repoResult = await _distRepo.BulkCreateDist(listdata, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Dist Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Created,
                        },
                        false => new()
                        {
                            Data = repoResult.Records,
                            Message = repoResult.ResponseCode == 400 ? repoResult.Message : "Dist already exist",
                            ResponseCode = repoResult.ResponseCode == 400 ? (int)ResponseCode.Status.BadRequest : (int)ResponseCode.Status.Found,
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkCreateDist", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateDist(DistUpdateModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationResult = await _distUpdateValidator.ValidateAsync(data);
                if (validationResult.IsValid)
                {
                    var repoResult = await _distRepo.UpdateDist(data, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Dist Updated Successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        },
                        false => new()
                        {
                            Message = $"DistId '{data.DistId}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "UpdateDist", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkUpdateDist(List<DistUpdateModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationTasks = listdata.Select(b => _distUpdateValidator.ValidateAsync(b));
                var validationResults = await Task.WhenAll(validationTasks);
                if (validationResults.All(r => r.IsValid))
                {
                    var repoResult = await _distRepo.BulkUpdateDist(listdata, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Dists Updated Successfully",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkUpdateDist", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveDist(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _distRepo.RemoveDist(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Dist Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"DistId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RemoveDist", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkRemoveDist(List<DistUpdateModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _distRepo.BulkRemoveDist(listdata, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = $"{repoResult.Count} removed , {listdata.Count - repoResult.Count} failed",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RemoveBranch", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedDists(PaginationParams pagination)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _distRepo.GetRemovedDists(pagination);
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetRemovedDists", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverDist(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _distRepo.RecoverDist(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Dist Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Data = repoResult.Records,
                        Message = repoResult.ResponseCode == 302 ? $"Unable to recover due to an  active record found" : $"DistId '{Id}' not found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RecoverDist", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkRecoverDists(List<DistUpdateModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _distRepo.BulkRecoverDists(listdata, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = $"{repoResult.Count} recovered , {listdata.Count - repoResult.Count} failed",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To Recover Dists",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RecoverAllDists", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteDist(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _distRepo.DeleteDist(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "Dist Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"DistId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteDist", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkDeleteDists(List<Guid> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _distRepo.BulkDeleteDists(Ids, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = $"{repoResult.Count} deleted, {Ids.Count - repoResult.Count} failed",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed To delete Dists",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkDeleteDists", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
       
    }
}
