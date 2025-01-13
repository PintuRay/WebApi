using System.ComponentModel.DataAnnotations;

namespace FMS.Model.Account.Authentication
{
    public class ResetPasswordModel
    {
        public string UserId { get; set; }
        public string Token {  get; set; }
        public string NewPassword { get; set; }
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
