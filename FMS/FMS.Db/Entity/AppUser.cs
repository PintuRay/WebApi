using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace FMS.Db.Entity
{

    public class AppUser : IdentityUser
    {
        public Guid FkTokenId { get; set; }
        public string Name { get; set; }
        //Reference Navigation Property
        public RegisterToken Token { get; set; }
        //collection Navigation Property
        public ICollection<UserBranch> UserBranch { get; set; }
    }
    internal class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(e => e.FkTokenId).HasColumnType("uniqueidentifier").IsRequired(true);
            builder.Property(e => e.Name).HasMaxLength(50).IsRequired(true);
            //One-tO-One Relationship
            builder.HasOne(d => d.Token).WithOne(p => p.User).HasForeignKey<AppUser>(d => d.FkTokenId).OnDelete(DeleteBehavior.Restrict);
            builder.HasData(
            new AppUser
            {
                Id = "4431f16a-6bc7-4e9b-bada-c491fcc81a58",
                FkTokenId = Guid.Parse("3f7c3a85-1e6f-4c2a-8f5e-1234567890ab"),
                Name = "Pintu Ray",
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
            }
        );
        }
    }
}
