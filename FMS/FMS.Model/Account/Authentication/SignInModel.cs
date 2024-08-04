using System.ComponentModel.DataAnnotations;

namespace FMS.Model.Account.Authentication
{
    public class SignInModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}
