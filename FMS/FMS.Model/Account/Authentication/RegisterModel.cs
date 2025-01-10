using FluentValidation;
using FMS.Db.CustomVaidator;
using FMS.Db.Entity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FMS.Model.Account.Authentication
{
    public class RegisterModel
    {
        [Required]
        public Guid FkTokenId { get; set; }
        [Required, StringLength(30, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string MaratialStatus { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public IFormFile ProfilePhoto { get; set; }
        [Required]
        public  string Email { get; set; }
        [Required]
        public  string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string RouteUls { get; set; }
        public string PhotoPath { get; set; }
        [Required]
        public AddressModel Address { get; set; }
    }
    public class RegisterValidator : AbstractValidator<RegisterModel>
    {
        public RegisterValidator(CustomValidation vaidator)
        {
            // Validate Token
            RuleFor(user => user.FkTokenId)
            .NotNull().WithMessage("Token Id is required.")
            .NotEmpty().WithMessage("TokenId cannot be empty.");
            // Validate Name
            RuleFor(user => user.Name)
             .NotNull().WithMessage("Username is required.")
             .NotEmpty().WithMessage("Username cannot be empty.")
             .Length(5, 30).WithMessage("Username must be between 5 and 30 characters.")
             .Custom((name, context) =>
             {
                 bool isExists = vaidator.BeUniqueUsername(name).Result;
                 if (isExists)
                 {
                     context.AddFailure($"User Name{name} already Taken");
                 }
             });
            // Validate BirthDate
            RuleFor(user => user.BirthDate)
                .NotNull().WithMessage("Birth date is required.")
                .NotEmpty().WithMessage("Birth date cannot be empty.");
                //.LessThanOrEqualTo(DateTime.Now.AddYears(-100)).WithMessage("Birth date cannot be earlier than 100 years ago.");

            // Validate Marital Status
            RuleFor(user => user.MaratialStatus)
                .NotNull().WithMessage("Marital status is required.")
                .NotEmpty().WithMessage("Marital status cannot be empty.");

            // Validate Gender
            RuleFor(user => user.Gender)
                .NotNull().WithMessage("Gender is required.")
                .NotEmpty().WithMessage("Gender cannot be empty.");

           // Validate Profile Photo
            RuleFor(user => user.ProfilePhoto)
                 .NotNull().WithMessage("Profile photo is required.")
                 .Must(file => file != null &&
                     (file.ContentType.Equals("image/jpeg") ||
                      file.ContentType.Equals("image/jpg") ||
                      file.ContentType.Equals("image/png") ||
                      file.ContentType.Equals("image/gif") ||
                      file.ContentType.Equals("image/webp")))
                 .WithMessage("Only JPEG, JPG, PNG, GIF, or WebP images are allowed.")
                 .Must(file => file != null && file.Length <= 5 * 1024 * 1024) // 5MB limit
                 .WithMessage("Image size must be less than 5MB.");

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
            // Validate Phone No
            RuleFor(user => user.PhoneNumber)
                 .NotNull().WithMessage("Phone number is required.")
                .NotEmpty().WithMessage("Phone number  cannot be empty.")
                .Matches(@"^\d{10}$").WithMessage("Phone number should be 10 digit")
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
            // Validate routeUrl
            RuleFor(user => user.RouteUls)
            .NotNull().WithMessage("RouteUls is required.")
            .NotEmpty().WithMessage("RouteUls cannot be empty.");
        }
    }
}
