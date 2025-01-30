using FluentValidation;
using FMS.Db.CustomVaidator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class RegisterTokenModel
    {
        [Required]
        public string TokenValue { get; set; }
    }
    public class RegisterToken: RegisterTokenModel
    {
        public Guid TokenId { get; set; }
        public bool? IsActive { get; set; }
        //Reference Navigation Property
        public AppUser User { get; set; }
    }
    public class RegisterTokenValidator : AbstractValidator<RegisterTokenModel>
    {
        public RegisterTokenValidator()
        {
            // Validate Token
            RuleFor(tregkoken => tregkoken.TokenValue)
             .Matches(@"^\d{3}-\d{3}-\d{4}$").WithMessage("Registration Token Format Mismatch");
        }
    }
    internal class RegisterTokenConfig : IEntityTypeConfiguration<RegisterToken>
    {
        public void Configure(EntityTypeBuilder<RegisterToken> builder)
        {
            builder.ToTable("RegisterTokens", "public");
            builder.HasKey(e => e.TokenId);
            builder.Property(e => e.TokenId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.TokenValue).HasMaxLength(150);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.HasData(
                new RegisterToken
                {
                    TokenId = Guid.Parse("3f7c3a85-1e6f-4c2a-8f5e-1234567890ab"),
                    TokenValue = "123-123-1234",
                    IsActive = true,
                }
             );
        }
    }
}
