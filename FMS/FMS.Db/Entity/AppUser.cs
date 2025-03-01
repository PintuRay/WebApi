using FluentValidation;
using FMS.Db.CustomVaidator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
namespace FMS.Db.Entity
{
    public class AppUser : IdentityUser
    {
        public Guid Fk_TokenId { get; set; }
        public Guid Fk_AdressId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaratialStatus { get; set; }
        public string Gender { get; set; }
        public string PhotoPath { get; set; }
        public bool? TermCondition { get; set; }
        public RegisterToken Token { get; set; }
        public Address Address { get; set; }
        public ICollection<UserBranch> UserBranch { get; set; }
    }
    internal class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(e => e.Fk_TokenId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_AdressId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.BirthDate).HasColumnType("timestamptz").IsRequired(true);
            builder.Property(e => e.MaratialStatus).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.Gender).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.PhotoPath).IsRequired(false);
            builder.Property(e => e.TermCondition).HasDefaultValueSql("true");
            //One-To-One Relationship
            builder.HasOne(d => d.Token).WithOne(p => p.User).HasForeignKey<AppUser>(d => d.Fk_TokenId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Address).WithOne(p => p.User).HasForeignKey<AppUser>(d => d.Fk_AdressId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
            new AppUser
            {
                Id = "4431f16a-6bc7-4e9b-bada-c491fcc81a58",
                Fk_TokenId = Guid.Parse("3f7c3a85-1e6f-4c2a-8f5e-1234567890ab"),
                Fk_AdressId= Guid.Parse("c9b62c55-1b06-485d-a71b-d92fee4f4428"),
                Name = "Pintu Ray",
                Gender = "male",
                MaratialStatus = "unmarred",
                BirthDate = DateTime.SpecifyKind(DateTime.Parse("1993-07-04"), DateTimeKind.Utc),
                Email = "raypintu959@gmail.com",
                UserName = "raypintu959@gmail.com",
                PhoneNumber = "8249486590",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = true,
                LockoutEnabled = true,
                NormalizedUserName = "RAYPINTU959@GMAIL.COM",
                NormalizedEmail = "RAYPINTU959@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEGCZJkRuuaN5s6jesxs7zm4NBR99KorCbeWBm6yVLgn2JCBVFEKr5ui4hLYFkhQWCA==",
                SecurityStamp = "ZCKN4FWVQMFYYU3JWBLJN7UUN2CBOZMF",
                ConcurrencyStamp = "65a37859-d054-4a68-a817-1669d83c598a",
                TermCondition = true
            }
        );
        }
    }
    public class UserBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string MaratialStatus { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string PhotoPath { get; set; }
       
    }
    public class UserModel : UserBase
    {
        [Required]
        public Guid Fk_TokenId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string RouteUls { get; set; }
        public IFormFile ProfilePhoto { get; set; }
        public AddressModel Address { get; set; }
    }
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator(CustomValidation vaidator)
        {
            // Validate Name           
            RuleFor(user => user.Name)
             .Length(5, 30).WithMessage("Username must be between 5 and 30 characters.")
             .Custom((name, context) =>
             {
                 bool isExists = vaidator.BeUniqueUsername(name).Result;
                 if (isExists)
                 {
                     context.AddFailure($"User Name{name} already Taken");
                 }
             });
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
                  .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&*!])[A-Za-z\d@#$%^&*!]{8,}$")
                  .WithMessage("Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one digit, and one special character.");
            // Validate Confirm Password
            RuleFor(user => user.ConfirmPassword)
                .Equal(user => user.Password).WithMessage("The password and confirmation password do not match.");
        }
    }
    public class UserUpdateModel : UserBase
    {
        [Required]
        public string Id { get; set; }
        public IFormFile ProfilePhoto { get; set; }
        public AddressUpdateModel Address { get; set; }
    }
    public class UserDto : UserBase
    {
        public string Id { get; set; }
        public AddressDto Address { get; set; }
    }
}
