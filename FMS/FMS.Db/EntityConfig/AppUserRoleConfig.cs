using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Db.EntityConfig
{
    public class AppUserRoleConfig : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasData(
                new AppUserRole
                {
                    UserId = "4431f16a-6bc7-4e9b-bada-c491fcc81a58",
                    RoleId = "71f97dea-8c5f-4f51-84c7-6d7a16e64651",
                    CreatedBy = "System",
                    CreatedDate = DateTime.UtcNow,
                    ModifyBy = "System",
                    ModifyDate = DateTime.UtcNow
                }
             );
        }
    }
}
