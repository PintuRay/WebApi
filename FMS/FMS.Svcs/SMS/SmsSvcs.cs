using FMS.Model.SMS;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Net.Http.Headers;
namespace FMS.Svcs.SMS
{
    public class SmsSvcs(IOptions<SmsConfigModel> smsConfig) : ISmsSvcs
    {
        private readonly SmsConfigModel _smsConfig = smsConfig.Value;
        public async Task<bool> SendSmsAsync(string to, string message)
        {
            try
            {
                TwilioClient.Init(_smsConfig.AccountSid, _smsConfig.AuthToken);
                var msg = await MessageResource.CreateAsync(
                     to: new Twilio.Types.PhoneNumber(to),
                     from: new Twilio.Types.PhoneNumber(_smsConfig.PhoneNumber),
                      body: message
                    );
                return true;
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error sending SMS: {ex.Message}");
                 return false;
            }
        }
    }
}
