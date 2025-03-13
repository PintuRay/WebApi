using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Common.Address
{
    public class AddressRepo(Context ctx, IMapper mapper) : IAddressRepo
    {
        #region Dependancy
        private readonly Context _ctx = ctx;
        private readonly IMapper _mapper = mapper;

        #endregion
        public async Task<RepoBase> CreateAdress(AddressModel data)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var newAddress = _mapper.Map<Db.Entity.Address>(data);
                await _ctx.Addresses.AddAsync(newAddress);
                int Count = await _ctx.SaveChangesAsync();
                if (Count > 0)
                {
                    _Result.Records = newAddress;
                    _Result.IsSucess = true;
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkCreateAdress(List<AddressModel> datalist)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var newAddresses = datalist.Select(data => _mapper.Map<Db.Entity.Address>(data)).ToList();
                var response = await _ctx.BulkInsert(newAddresses);
                if (response.IsSuccess)
                {
                    await transaction.CommitAsync();
                    //_Result.Count = response.AffectedRows;
                    _Result.IsSucess = true;
                    _Result.Records = newAddresses;
                }
                else
                {
                    await transaction.RollbackAsync();
                    _Result.ResponseCode = 400;
                    _Result.Message = "Failed to create Adresses";
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> UpdateAdress(AddressUpdateModel data)
        {
            RepoBase _Result = new();
            try
            {
                _Result.IsSucess = false;
                var existingAddress = await _ctx.Addresses.SingleOrDefaultAsync(s => s.AddressId == data.AddressId && s.IsActive == true);
                if (existingAddress != null)
                {
                    var addressToUpdate = _mapper.Map(data, existingAddress);
                    int Count = await _ctx.SaveChangesAsync();
                    if (Count > 0)
                    {
                        _Result.IsSucess = true;
                        _Result.Records = existingAddress;
                        //_Result.Count = Count;
                    
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
        public async Task<RepoBase> BulkUpdateAdress(List<AddressUpdateModel> datalist)
        {
            RepoBase _Result = new();
            using var transaction = await _ctx.Database.BeginTransactionAsync();
            try
            {
                _Result.IsSucess = false;
                var existingAdresses = await _ctx.Addresses.Where(b => b.IsActive == true && datalist.Select(br => br.AddressId).Contains(b.AddressId)).ToListAsync();
                var notFoundAdresses= datalist.Where(br => !existingAdresses.Any(b => b.AddressId == br.AddressId)).ToList();
                if (notFoundAdresses.Count == 0)
                {
                    var countriesToUpdate = existingAdresses.Select(s =>
                    {
                        var updateData = datalist.First(u => u.AddressId == s.AddressId);
                        _mapper.Map(updateData, s);
                        return s;
                    }).ToList();
                    var response = await _ctx.BulkUpdate(countriesToUpdate);
                    if (response.IsSuccess)
                    {
                        await transaction.CommitAsync();
                        _Result.IsSucess = true;
                        //_Result.Count = response.AffectedRows;
                        _Result.Records = countriesToUpdate;
                      
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        _Result.ResponseCode = 400;
                        _Result.Message = "Failed to update adresses";
                    }
                }
                else
                {
                    _Result.Records = notFoundAdresses;
                }
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return _Result;
        }
    }
}
