using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Db.EntityConfig
{
    internal class UserBranchConfig : IEntityTypeConfiguration<UserBranch>
    {
        public void Configure(EntityTypeBuilder<UserBranch> builder)
        {
            builder.ToTable("UserBranches", "dbo");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_BranchId).IsRequired(true);
            builder.Property(e => e.Fk_UserId).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            //One-To-Many Relationship
            builder.HasOne(ub => ub.User).WithMany(u => u.UserBranch).HasForeignKey(ub => ub.Fk_UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(ub => ub.Branch).WithMany(b => b.UserBranch).HasForeignKey(ub => ub.Fk_BranchId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
