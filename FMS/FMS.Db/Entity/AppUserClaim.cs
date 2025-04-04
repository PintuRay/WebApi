﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class AppUserClaim: IdentityUserClaim<string>
    {

    }
    internal class AppUserClaimConfig : IEntityTypeConfiguration<AppUserClaim>
    {
        public void Configure(EntityTypeBuilder<AppUserClaim> builder)
        {
            builder.HasData(
                new AppUserClaim
                {
                    Id = 1,
                    UserId = "4431f16a-6bc7-4e9b-bada-c491fcc81a58",
                    ClaimType = "Create",
                    ClaimValue = "Create",
                },
                  new AppUserClaim
                  {
                      Id = 2,
                      UserId = "4431f16a-6bc7-4e9b-bada-c491fcc81a58",
                      ClaimType = "Update",
                      ClaimValue = "Update",
                  },
                    new AppUserClaim
                    {
                        Id = 3,
                        UserId = "4431f16a-6bc7-4e9b-bada-c491fcc81a58",
                        ClaimType = "Delete",
                        ClaimValue = "Delete",
                    }
                );
        }
    }
}
