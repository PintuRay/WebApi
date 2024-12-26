using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace FMS.Db.Entity
{

    public class AppUser : IdentityUser
    {
        public Guid Fk_TokenId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaratialStatus { get; set; }
        public string Gender { get; set; }
        public string PhotoPath { get; set; }
        public bool TermCondition { get; set; }
        //Reference Navigation Property
        public RegisterToken Token { get; set; }
        //collection Navigation Property
      public ICollection<UserBranch> UserBranch { get; set; }
    }
    internal class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(e => e.Fk_TokenId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.BirthDate).HasColumnType("timestamptz").IsRequired(true);
            builder.Property(e => e.MaratialStatus).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.Gender).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.PhotoPath).IsRequired(false);
            builder.Property(e => e.TermCondition).HasDefaultValueSql("true");
            //One-To-One Relationship
            builder.HasOne(d => d.Token).WithOne(p => p.User).HasForeignKey<AppUser>(d => d.Fk_TokenId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
            new AppUser
            {
                Id = "4431f16a-6bc7-4e9b-bada-c491fcc81a58",
                Fk_TokenId = Guid.Parse("3f7c3a85-1e6f-4c2a-8f5e-1234567890ab"),
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
                TermCondition= true
            }
        );
        }
    }
}
