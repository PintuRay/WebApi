using FMS.Db.Entity;

namespace FMS.Svcs.Common.Address
{
    public interface IAddressSvcs
    {
        public Task<SvcsBase> CreateAdress(AddressModel data);
        public Task<SvcsBase> UpdateAdress(AddressUpdateModel data);
        public Task<SvcsBase> BulkCreateAdress(List<AddressModel> datalist);
        public Task<SvcsBase> BulkUpdateAdress(List<AddressUpdateModel> datalist);
    }
}
