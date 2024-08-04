using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Model.SMS
{
    public class SmsConfigModel
    {
        public string PhoneNumber { get; set; }
        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
    }
}
