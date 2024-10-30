using FluentValidation;
using FMS.Db.CustomVaidator;

namespace FMS.Model.Account.Authentication
{
    public class RegisterModel
    {
        public Guid FkTokenId { get; set; }
        public string Name { get; set; }
        public  string Email { get; set; }
        public  string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string RouteUls { get; set; }
        public bool TermCondition { get; set; }
    }
    public class RegisterValidator : AbstractValidator<RegisterModel>
    {
        public RegisterValidator(CustomValidation vaidator)
        {
            // Validate Name
            RuleFor(user => user.Name)
             .NotNull().WithMessage("Username is required.")
             .NotEmpty().WithMessage("Username cannot be empty.")
             .Length(5, 30).WithMessage("Username must be between 5 and 30 characters.")
             .Custom((name, context) =>
             {
                 bool isExists = vaidator.BeUniqueEmail(name).Result;
                 if (isExists)
                 {
                     context.AddFailure($"User Name{name} already Taken");
                 }
             });
            // Validate Email
            RuleFor(user => user.Email)
                .NotNull().WithMessage("Email is required.")
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Invalid email format.")
                .Custom((email, context) =>
                {
                    bool isExists = vaidator.BeUniqueEmail(email).Result;
                    if (isExists)
                    {
                        context.AddFailure($"{email} is already registered");
                    }
                });
            RuleFor(user => user.PhoneNumber)
                 .NotNull().WithMessage("Phone number is required.")
                .NotEmpty().WithMessage("Phone number  cannot be empty.")
                .Matches(@"^\d{10}$").WithMessage("Phone number shoild be 10 digit")
                .Custom((phno, context) =>
                {
                    bool isExists = vaidator.BeUniquePhoneNumber(phno).Result;
                    if (isExists)
                    {
                        context.AddFailure($"{phno} is already registered");
                    }
                });
            // Validate Password
            RuleFor(user => user.Password)
                  .NotNull().WithMessage("Password is required.")
                  .NotEmpty().WithMessage("Password cannot be empty.")
                  .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&*!])[A-Za-z\d@#$%^&*!]{8,}$")
                  .WithMessage("Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character.");
            // Validate Confirm Password
            RuleFor(user => user.ConfirmPassword)
                .NotNull().WithMessage("Confirmation password is required.")
                .NotEmpty().WithMessage("Confirmation password cannot be empty.")
                .Equal(user => user.Password).WithMessage("The password and confirmation password do not match.");
        }
    }

}
