using FMS.Db.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.EntityConfig
{
    internal class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branches", "dbo");
            builder.HasKey(e => e.BranchId);
            builder.Property(e => e.BranchId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.BranchName).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.BranchAddress).HasMaxLength(500).IsRequired(true);
            builder.Property(e => e.BranchCode).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.ContactNumber).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100); 
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
        }
    }
}
