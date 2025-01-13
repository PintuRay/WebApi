using FMS.Model.Email;
using FMS.Repo;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace FMS.Svcs.Email
{
    public class EmailSvcs(IOptions<SMTPConfigModel> smtpConfig) : IEmailSvcs
    {
        private const string templatePath = @"EmailTemplate/{0}.html";
        private readonly SMTPConfigModel _smtpConfig = smtpConfig.Value;
        public async Task<bool> SendConfirmationEmail(UserEmailOptions options)
        {
            options.Subject = UpdatePlaceHolders("Hello {{UserName}}, Confirm your email id.", options.PlaceHolders);
            options.Body = UpdatePlaceHolders(GetEmailBody("EmailConfirm"), options.PlaceHolders);
            return await SendEmail(options);
        }
        public async Task<bool> SendTwoFactorToken(UserEmailOptions options)
        {
            options.Subject = UpdatePlaceHolders("Hello {{UserName}}", options.PlaceHolders);
            options.Body = UpdatePlaceHolders(GetEmailBody("ConfirmOtp"), options.PlaceHolders);
            return await SendEmail(options);
        }
        private static string UpdatePlaceHolders(string text, List<KeyValuePair<string, string>> keyValuePairs)
        {
            if (!string.IsNullOrEmpty(text) && keyValuePairs != null)
            {
                foreach (var placeholder in keyValuePairs)
                {
                    if (text.Contains(placeholder.Key))
                    {
                        text = text.Replace(placeholder.Key, placeholder.Value);
                    }
                }
            }
            return text;
        }
        private static string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;
        }
        private async Task<bool> SendEmail(UserEmailOptions userEmailOptions)
        {
            try
            {
                using var message = new MailMessage();
                message.From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName);
                message.To.Add(userEmailOptions.ToEmail);
                message.Subject = userEmailOptions.Subject;
                message.Body = userEmailOptions.Body;
                message.IsBodyHtml = _smtpConfig.IsBodyHTML;
                using (SmtpClient smtpClient = new())
                {
                    smtpClient.Host = _smtpConfig.Host;
                    smtpClient.Port = _smtpConfig.Port;
                    smtpClient.EnableSsl = _smtpConfig.EnableSSL;
                    //smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password);
                    await smtpClient.SendMailAsync(message);
                };
                return true;
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"SMTP Exception: {ex.Message}");
                Console.WriteLine($"SMTP Server Response: {ex.StatusCode}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public async Task<bool> SendResetPasswordEmail(UserEmailOptions options)
        {
            try
            {
                bool result = await SendEmailForResetPassword(options);
                return result;
            }
            catch
            {
                return false;
            }
        }
        private async Task<bool> SendEmailForResetPassword(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.Subject = UpdatePlaceHolders("Hello {{UserName}}, reset your password.", userEmailOptions.PlaceHolders);
            userEmailOptions.Body = UpdatePlaceHolders(GetEmailBody("ForgotPassword"), userEmailOptions.PlaceHolders);
           bool isMailSend =  await SendEmail(userEmailOptions);
            return isMailSend;
        }
        public async Task SendExceptionEmail(string toEmail, string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient(_smtpConfig.Host)
                {
                    Port = _smtpConfig.Port,
                    Credentials = new NetworkCredential(_smtpConfig.UserName, _smtpConfig.Password),
                    EnableSsl = _smtpConfig.EnableSSL,
                };
                using var message = new MailMessage();
                message.From = new MailAddress(_smtpConfig.SenderAddress, _smtpConfig.SenderDisplayName);
                message.To.Add(toEmail);
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = _smtpConfig.IsBodyHTML;
                await smtpClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
