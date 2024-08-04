using System.Security.Claims;

namespace FMS.Model.Account.Authentication
{
    public class UserSession
    {
        public string Id;
        public string Name;
        public string Email;
        public string Role;
        public List<Claim> Claims;
    }
}
