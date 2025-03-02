using FMS.Db.Entity;
using FMS.Model;
using FMS.Repo.Common.State;
using FMS.Svcs.Email;

namespace FMS.Svcs.Common.State
{
    public class StateSvcs(IStateRepo stateRepo, IEmailSvcs emailSvc, StateValidator stateValidator, StateUpdateValidator stateUpdateValidator) : IStateSvcs
    {
        #region Dependancy
        private readonly IStateRepo _stateRepo = stateRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        private readonly StateValidator _stateValidator = stateValidator;
        private readonly StateUpdateValidator _stateUpdateValidator = stateUpdateValidator;
        #endregion
        #region Crud
        public async Task<SvcsBase> GetStates(Guid CountryId)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _stateRepo.GetStates(CountryId);
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetStates", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> GetStates(PaginationParams pagination)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _stateRepo.GetStates(pagination);
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetStates", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateState(StateModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationResult = await _stateValidator.ValidateAsync(data);
                if (validationResult.IsValid)
                {
                    var repoResult = await _stateRepo.CreateState(data, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "State Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Created,
                        },
                        false => new()
                        {
                            Message = $"State '{data.StateName}' Already Exist",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "CreateState", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkCreateState(List<StateModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationTasks = listdata.Select(b => _stateValidator.ValidateAsync(b));
                var validationResults = await Task.WhenAll(validationTasks);
                if (validationResults.All(r => r.IsValid))
                {
                    var repoResult = await _stateRepo.BulkCreateState(listdata, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "State Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Created,
                        },
                        false => new()
                        {
                            Data = repoResult.Records,
                            Message = repoResult.ResponseCode == 400 ? repoResult.Message : "State already exist",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkCreateState", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateState(StateUpdateModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationResult = await _stateUpdateValidator.ValidateAsync(data);
                if (validationResult.IsValid)
                {
                    var repoResult = await _stateRepo.UpdateState(data, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "State Updated Successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        },
                        false => new()
                        {
                            Message = $"StateId '{data.StateId}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "UpdateState", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkUpdateState(List<StateUpdateModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationTasks = listdata.Select(b => _stateUpdateValidator.ValidateAsync(b));
                var validationResults = await Task.WhenAll(validationTasks);
                if (validationResults.All(r => r.IsValid))
                {
                    var repoResult = await _stateRepo.BulkUpdateState(listdata, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "States Updated Successfully",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkUpdateState", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveState(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _stateRepo.RemoveState(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "State Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"StateId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RemoveState", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkRemoveState(List<StateUpdateModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _stateRepo.BulkRemoveState(listdata, user);
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
                        Message = $"Failed to  remove States",
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
        public async Task<SvcsBase> GetRemovedStates(PaginationParams pagination)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _stateRepo.GetRemovedStates(pagination);
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetRemovedStates", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverState(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _stateRepo.RecoverState(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "State Recovered Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Data = repoResult.Records,
                        Message = repoResult.ResponseCode == 302 ? $"Unable to recover due to an  active record found" : $"StateId '{Id}' not found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RecoverState", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkRecoverStates(List<StateUpdateModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _stateRepo.BulkRecoverStates(listdata, user);
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
                        Message = "Failed To Recover States",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RecoverAllStates", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteState(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _stateRepo.DeleteState(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult,
                        Message = "State Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"StateId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteState", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkDeleteStates(List<Guid> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _stateRepo.BulkDeleteStates(Ids, user);
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
                        Message = "Failed To delete States",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteAllStates", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
    }
}
