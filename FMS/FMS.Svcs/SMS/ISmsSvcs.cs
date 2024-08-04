using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Svcs.SMS
{
    public interface ISmsSvcs
    {
        Task<bool> SendSmsAsync(string to, string message);
    }
}
