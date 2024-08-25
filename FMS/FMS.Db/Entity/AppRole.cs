using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Db.Entity
{
    public class AppRole: IdentityRole
    {

    }
    internal class AppRoleConfig : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {

            builder.HasData(
           new AppRole
           {
               Id = "438df919-342f-4ddf-87c4-6d7a16e64651",
               Name = "User",
               NormalizedName = "USER",
           },
            new AppRole
            {
                Id = "5c3a5755-95c7-4f51-84c7-6d7a16e64651",
                Name = "Admin",
                NormalizedName = "ADMIN",
            },
            new AppRole
            {
                Id = "71f97dea-8c5f-4f51-84c7-6d7a16e64651",
                Name = "Devloper",
                NormalizedName = "DEVLOPER",
            }
        );
        }
    }
}
