using FMS.Db.Entity;
using FMS.Repo.Common.Address;
using FMS.Svcs.Email;

namespace FMS.Svcs.Common.Address
{
    public class AddressSvcs(IAddressRepo addressRepo, AddressValidator addressValidator, AddressUpdateValidator addressUpdateValidator, IEmailSvcs emailSvc) : IAddressSvcs
    {
        #region Dependancy
        private readonly IAddressRepo _addressRepo = addressRepo;
        private readonly AddressValidator _addressValidator = addressValidator;
        private readonly AddressUpdateValidator _addressUpdateValidator = addressUpdateValidator;
        private readonly IEmailSvcs _emailSvcs = emailSvc;
        #endregion
        public async Task<SvcsBase> CreateAdress(AddressModel data)
        {
            SvcsBase Obj;
            try
            {
                var validationResult = await _addressValidator.ValidateAsync(data);
                if (validationResult.IsValid)
                {
                    var repoResult = await _addressRepo.CreateAdress(data);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Address Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Created,
                        },
                        false => new()
                        {
                            Message = $"Address Already Exist",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "CreateAddress", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkCreateAdress(List<AddressModel> datalist)
        {
            SvcsBase Obj;
            try
            {
                var validationTasks = datalist.Select(b => _addressValidator.ValidateAsync(b));
                var validationResults = await Task.WhenAll(validationTasks);
                if (validationResults.All(r => r.IsValid))
                {
                    var repoResult = await _addressRepo.BulkCreateAdress(datalist);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Address Created Successfully",
                            ResponseCode = (int)ResponseCode.Status.Created,
                        },
                        false => new()
                        {
                            Data = repoResult.Records,
                            Message = repoResult.ResponseCode == 400 ? repoResult.Message : "Adress already exist",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkCreateAdress", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> UpdateAdress(AddressUpdateModel data)
        {
            SvcsBase Obj;
            try
            {
                var validationResult = await _addressUpdateValidator.ValidateAsync(data);
                if (validationResult.IsValid)
                {
                    var repoResult = await _addressRepo.UpdateAdress(data);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Address updated successfully",
                            ResponseCode = (int)ResponseCode.Status.Ok,
                        },
                        false => new()
                        {
                            Message = $"Address not found",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "UpdateAdress", _Exception.ToString());
            }
            return Obj;
        }
        public async Task<SvcsBase> BulkUpdateAdress(List<AddressUpdateModel> datalist)
        {
            SvcsBase Obj;
            try
            {
                var validationTasks = datalist.Select(b => _addressUpdateValidator.ValidateAsync(b));
                var validationResults = await Task.WhenAll(validationTasks);
                if (validationResults.All(r => r.IsValid))
                {
                    var repoResult = await _addressRepo.BulkUpdateAdress(datalist);
                    Obj = repoResult.IsSucess switch
                    {
                        true => new()
                        {
                            Data = repoResult,
                            Message = "Adresses Updated Successfully",
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
                await _emailSvcs.SendExceptionEmail("raypintu959@gmail.com", "BulkUpdateBranch", _Exception.ToString());
            }
            return Obj;
        }
    }
}
