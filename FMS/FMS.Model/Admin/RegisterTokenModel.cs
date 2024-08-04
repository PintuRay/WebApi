using System.ComponentModel.DataAnnotations;

namespace FMS.Model.Admin
{
    public class RegisterTokenModel
    {
        [Required(ErrorMessage = "TokenValue is required")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Invalid TokenValue format. Use the format: 123-654-1235")]
        public string TokenValue { get; set; }
    }
    public class RegisterTokenViewModel : RegisterTokenModel
    {
        public Guid TokenId { get; set; }
    }
}
