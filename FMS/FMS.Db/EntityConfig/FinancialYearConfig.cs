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
    internal class FinancialYearConfig : IEntityTypeConfiguration<FinancialYear>
    {
        public void Configure(EntityTypeBuilder<FinancialYear> builder)
        {
            builder.ToTable("FinancialYears", "dbo");
            builder.HasKey(e => e.FinancialYearId);
            builder.Property(e => e.FinancialYearId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Financial_Year).IsRequired(true);
            builder.Property(e => e.StartDate).IsRequired(true).HasColumnType("datetime");
            builder.Property(e => e.EndDate).IsRequired(true).HasColumnType("datetime");
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
        }
    }
}
