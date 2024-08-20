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
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company", "dbo");
            builder.HasKey(e => e.CompanyId);
            builder.Property(e => e.CompanyId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.CompanyName).HasMaxLength(200).IsRequired(true);
            builder.Property(e => e.Fk_BranchId).IsRequired(true);
            builder.Property(e => e.Logo).IsRequired(true);
            builder.Property(e => e.State).IsRequired(true);
            builder.Property(e => e.Adress).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.GSTIN).IsRequired(true);
            builder.Property(e => e.Email).IsRequired(true);
            builder.Property(e => e.PhoneNo).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasOne(s => s.Branch).WithMany(e => e.Companies).HasForeignKey(e => e.Fk_BranchId);
        }
    }
}
