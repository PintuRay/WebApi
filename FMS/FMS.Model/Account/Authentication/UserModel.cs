using FMS.Model.Account.Autherization;
using FMS.Model.Devloper;
using System.ComponentModel.DataAnnotations;
namespace FMS.Model.Account.Authentication
{
    public class UserModel
    {
        [Required]
        public Guid FkTokenId { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConformPassword { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }
    }
    public class UserDbModel : UserModel
    {
        public string Id { get; set; }
        public string EmailConfirmationToken { get; set; } = null;
        public string OTP { get; set; } = null;
    }
}
