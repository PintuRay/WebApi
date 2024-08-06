using System.ComponentModel.DataAnnotations;
namespace FMS.Model.Account.Authentication
{
    public class UserModel
    {
        public string Token { get; set; }
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
        public string RouteUls { get; set; }
    }
    public class UserViewModel : UserModel
    {
        public string Id { get; set; }
        public string EmailConfirmationToken { get; set; } = null;
        public string OTP { get; set; } = null;
    }
}
