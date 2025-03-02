using FMS.Db.Entity;

namespace FMS.Svcs.Common.Address
{
    public interface IAddressSvcs
    {
        public Task<SvcsBase> CreateAdress(AddressModel data);
        public Task<SvcsBase> UpdateAdress(AddressUpdateModel data);
    }
}
