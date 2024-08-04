using FMS.Model.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Svcs.Email
{
    public interface IEmailSvcs
    {
        Task<bool> SendConfirmationEmail(UserEmailOptions options);
        Task<bool> SendTwoFactorToken(UserEmailOptions options);
        Task<bool> SendResetPasswordEmail(UserEmailOptions options);
        Task SendExceptionEmail(string toEmail, string subject, string body);
    }
}
