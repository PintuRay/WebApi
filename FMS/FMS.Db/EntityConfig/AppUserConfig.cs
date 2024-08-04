using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.EntityConfig
{
    internal class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(e => e.FkTokenId).HasColumnType("uniqueidentifier").IsRequired(true); 
            builder.Property(e => e.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.EmailConfirmationToken).IsRequired(false);
            builder.Property(e => e.OTP).IsRequired(false);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            //One-tO-One Relationship
            builder.HasOne(d => d.Token).WithOne(p => p.User).HasForeignKey<AppUser>(d => d.FkTokenId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
