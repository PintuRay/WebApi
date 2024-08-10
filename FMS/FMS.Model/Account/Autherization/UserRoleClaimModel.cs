using FMS.Model.Account.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Model.Account.Autherization
{
    public class UserRoleClaimModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<UserRoleModel> UserRoles { get; set; }
        public List<UserClaimModel> UserClaims { get; set; }
    }


}
