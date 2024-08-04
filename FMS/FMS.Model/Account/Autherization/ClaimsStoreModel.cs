using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
