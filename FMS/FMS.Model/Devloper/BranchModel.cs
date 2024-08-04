using FMS.Model.Admin;
using System.ComponentModel.DataAnnotations;
namespace FMS.Model.Devloper
{
    public class BranchModel
    {
        [Required,
         MinLength(3, ErrorMessage = "BranchName should be at least 3 characters long."),
        RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "BranchName should only contain letters and spaces.")]
        public string BranchName { get; set; }
        [Required]
        public string BranchAddress { get; set; }
        [Required,
         RegularExpression(@"^\d{10}$", ErrorMessage = "ContactNumber should have exactly 10 digits."),
        StringLength(10, ErrorMessage = "ContactNumber should have exactly 10 digits.",
        MinimumLength = 10)]
        public string ContactNumber { get; set; }
        [Required,
        RegularExpression(@"^[A-Z][A-Za-z0-9]*$", ErrorMessage = "BranchCode should start with a letter and followed by a combination of letters and numbers.")]
        public string BranchCode { get; set; }
    }
    public class BranchViewModel : BranchModel
    {
        public Guid BranchId { get; set; }
    }
   

}
