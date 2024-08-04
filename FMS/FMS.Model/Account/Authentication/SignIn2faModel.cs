using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Model.Account.Authentication
{
    public class SignIn2faModel
    {
        public string Email { get; set; }   
        public string OTP { get; set; }
    }
}
