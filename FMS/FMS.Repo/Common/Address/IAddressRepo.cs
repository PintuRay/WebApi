using FMS.Db.Entity;

namespace FMS.Repo.Common.Address
{
    public interface IAddressRepo
    {
        Task<RepoBase> CreateAdress(AddressModel data);
        Task<RepoBase> UpdateAdress(AddressUpdateModel data);
    }
}
