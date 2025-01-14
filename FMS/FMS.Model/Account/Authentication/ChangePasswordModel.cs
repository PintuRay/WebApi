using System.ComponentModel.DataAnnotations;

namespace FMS.Model.Account.Authentication
{
    public class ChangePasswordModel 
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
