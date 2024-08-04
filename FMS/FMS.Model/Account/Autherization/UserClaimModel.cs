using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Model.Account.Autherization
{
    public class UserClaimModel
    {
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public bool IsClaimSelected { get; set; }
    }
}
