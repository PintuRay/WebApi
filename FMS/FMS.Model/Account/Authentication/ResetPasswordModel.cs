using System.ComponentModel.DataAnnotations;

namespace FMS.Model.Account.Authentication
{
    public class ResetPasswordModel
    {
        public string NewPassword { get; set; }
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
