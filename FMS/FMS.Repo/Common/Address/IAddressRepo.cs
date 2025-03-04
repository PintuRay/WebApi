using FMS.Db.Entity;

namespace FMS.Repo.Common.Address
{
    public interface IAddressRepo
    {
        Task<RepoBase> CreateAdress(AddressModel data);
        Task<RepoBase> BulkCreateAdress(List<AddressModel> datalist);
        Task<RepoBase> UpdateAdress(AddressUpdateModel data);
        Task<RepoBase> BulkUpdateAdress(List<AddressUpdateModel> datalist);
    }
}
