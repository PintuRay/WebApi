using System.Security.Claims;

namespace FMS.Model.Account.Autherization
{
    public static class ClaimsStoreModel
    {
        public static List<Claim> AllClaims = new()
        {
        new Claim("Create", "Create"),

        new Claim("Update","Update"),

        new Claim("Delete","Delete")
        };
    }
}
