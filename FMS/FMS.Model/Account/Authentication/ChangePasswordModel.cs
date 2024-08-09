namespace FMS.Model.Account.Authentication
{
    public class ChangePasswordModel : ResetPasswordModel
    {
        public string CurrentPassword { get; set; }
    }
}
