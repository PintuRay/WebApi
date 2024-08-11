using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.EntityConfig
{
    public class AppRoleConfig : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasData(
           new AppRole
           {
               Id = "438df919-342f-4ddf-87c4-6d7a16e64651",
               Name = "User",
               NormalizedName = "USER",
               CreatedBy = "System",
               CreatedDate = DateTime.UtcNow,
               ModifyBy = "System",
               ModifyDate = DateTime.UtcNow
           },
            new AppRole
            {
                Id = "5c3a5755-95c7-4f51-84c7-6d7a16e64651",
                Name = "Admin",
                NormalizedName = "ADMIN",
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                ModifyBy = "System",
                ModifyDate = DateTime.UtcNow
            },
            new AppRole
            {
                Id = "71f97dea-8c5f-4f51-84c7-6d7a16e64651",
                Name = "Devloper",
                NormalizedName = "DEVLOPER",
                CreatedBy = "System",
                CreatedDate = DateTime.UtcNow,
                ModifyBy = "System",
                ModifyDate = DateTime.UtcNow
            }
        );
        }
    }
}
