using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace FMS.Db.Entity
{
    public class AppUserRole: IdentityUserRole<string>
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
    }
    internal class AppUserRoleConfig : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.HasData(
                new AppUserRole
                {
                    UserId = "4431f16a-6bc7-4e9b-bada-c491fcc81a58",
                    RoleId = "71f97dea-8c5f-4f51-84c7-6d7a16e64651",
                    CreatedBy = "System",
                    CreatedDate = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
                    ModifyBy = "System",
                    ModifyDate = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc)
                }
             );
        }
    }
}
