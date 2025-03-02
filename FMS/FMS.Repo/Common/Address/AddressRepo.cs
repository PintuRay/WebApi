using AutoMapper;
using FMS.Db;
using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;

namespace FMS.Repo.Common.Address
{
    public class AddressRepo(Context ctx, IMapper mapper): IAddressRepo
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
                    _Result.Id = newAddress.AddressId.ToString();
                    _Result.IsSucess = true;
                }
            }
            catch
            {
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
                        _Result.Records = existingAddress;
                        _Result.Count = Count;
                        _Result.IsSucess = true;
                    }
                }
            }
            catch
            {
                throw;
            }
            return _Result;
        }
    }
}
