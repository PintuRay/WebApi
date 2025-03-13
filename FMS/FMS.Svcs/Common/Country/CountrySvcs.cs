using FMS.Db.Entity;
using FMS.Model;
using FMS.Repo.Common.Country;
using FMS.Svcs.Email;

namespace FMS.Svcs.Common.Country
{
    public class CountrySvcs(ICountryRepo countryRepo, IEmailSvcs emailSvc, CountryValidator countryValidator, CountryUpdateValidator countryUpdateValidator) : ICountrySvcs
    {
        #region Dependancy
        private readonly ICountryRepo _countryRepo = countryRepo;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        private readonly CountryValidator _countryValidator = countryValidator;
        private readonly CountryUpdateValidator _countryUpdateValidator = countryUpdateValidator;
        #endregion
        #region Crud
        public async Task<SvcsBase> GetCountries()
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _countryRepo.GetAllCountries();
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetAllCountries", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> GetCountries(PaginationParams pagination)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _countryRepo.GetCountries(pagination);
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetCountries", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> CreateCountry(CountryModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationResult = await _countryValidator.ValidateAsync(data);
                if (validationResult.IsValid)
                {
                    var repoResult = await _countryRepo.CreateCountry(data, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult.Records,
                            Message = "Branch Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Created,
                        },
                        false => new()
                        {
                            Message = $"Branch '{data.CountryName}' Already Exist",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "CreateCountry", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkCreateCountry(List<CountryModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationTasks = listdata.Select(b => _countryValidator.ValidateAsync(b));
                var validationResults = await Task.WhenAll(validationTasks);
                if (validationResults.All(r => r.IsValid))
                {
                    var repoResult = await _countryRepo.BulkCreateCountry(listdata, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult.Records,
                            Message = "Country Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Created,
                        },
                        false => new()
                        {
                            Data = repoResult.Records,
                            Message = repoResult.ResponseCode == 400 ? repoResult.Message : "Country already exist",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkCreateCountry", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateCountry(CountryUpdateModel data, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationResult = await _countryUpdateValidator.ValidateAsync(data);
                if (validationResult.IsValid)
                {
                    var repoResult = await _countryRepo.UpdateCountry(data, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult.Records,
                            Message = "Country Updated Successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        },
                        false => new()
                        {
                            Message = $"CountryId '{data.CountryId}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "UpdateCountry", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkUpdateCountry(List<CountryUpdateModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var validationTasks = listdata.Select(b => _countryUpdateValidator.ValidateAsync(b));
                var validationResults = await Task.WhenAll(validationTasks);
                if (validationResults.All(r => r.IsValid))
                {
                    var repoResult = await _countryRepo.BulkUpdateCountry(listdata, user);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult.Records,
                            Message = "Countries Updated Successfully",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkUpdateCountry", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RemoveCountry(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _countryRepo.RemoveCountry(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.Records,
                        Message = "Country Removed Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"CountryId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RemoveCountry", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkRemoveCountry(List<CountryUpdateModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _countryRepo.BulkRemoveCountry(listdata, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.Records,
                        Message = $"{((List<Db.Entity.CountryDto>)repoResult.Records).Count} removed, {listdata.Count - ((List<Db.Entity.CountryDto>)repoResult.Records).Count} failed",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"Failed to  remove country",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkRemoveCountry", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
        #region Recover
        public async Task<SvcsBase> GetRemovedCountries(PaginationParams pagination)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _countryRepo.GetRemovedCountries(pagination);
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "GetRemovedCountries", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> RecoverCountry(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _countryRepo.RecoverCountry(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.Records,
                        Message = "Country recovered successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Data = repoResult.Records,
                        Message = repoResult.ResponseCode == 302 ? $"Unable to recover due to an  active record found" : $"countryId '{Id}' not found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "RecoverCountry", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkRecoverCountry(List<CountryUpdateModel> listdata, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _countryRepo.BulkRecoverCountry(listdata, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.Records,
                        Message = $"{((List<Db.Entity.CountryDto>)repoResult.Records).Count} recovered, {listdata.Count - ((List<Db.Entity.CountryDto>)repoResult.Records).Count} failed",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = "Failed to recover country",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkRecoverCountry", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> DeleteCountry(Guid Id, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _countryRepo.DeleteCountry(Id, user);
                Obj = repoResult.IsSucess switch
                {
                    true => new()
                    {
                        Data = repoResult.Id,
                        Message = "Country Deleted Successfully",
                        ResponseCode = (int)ResponseCode.Status.Ok,
                    },
                    false => new()
                    {
                        Message = $"CountryId '{Id}' Not Found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "DeleteCountry", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkDeleteCountry(List<Guid> Ids, AppUser user)
        {
            SvcsBase Obj;
            try
            {
                var repoResult = await _countryRepo.BulkDeleteCountry(Ids, user);
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
                        Message = "Failed To delete county",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkDeleteCountry", _Exception.ToString());
            }
            return Obj;
        }
        #endregion
    }
}
