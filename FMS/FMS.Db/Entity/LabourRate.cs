using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class LabourRateModel
    {
        public Guid Fk_FinancialYearId { get; set; }
        public DateTime Date { get; set; }
        public Guid Fk_ProductTypeId { get; set; }
        public Guid Fk_ProductId { get; set; }
        public Guid? Fk_BranchId { get; set; }
        public decimal Rate { get; set; }
    }
    public class LabourRate : LabourRateModel
    {
        public Guid LabourRateId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public ProductType ProductType { get; set; }
        public Product Product { get; set; }
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
    }
    internal class LabourRateConfig : IEntityTypeConfiguration<LabourRate>
    {
        public void Configure(EntityTypeBuilder<LabourRate> builder)
        {
            builder.ToTable("LabourRates", "dbo");
            builder.HasKey(e => e.LabourRateId);
            builder.Property(e => e.LabourRateId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_FinancialYearId).IsRequired(true);
            builder.Property(e => e.Date).HasColumnType("datetime").IsRequired(true);
            builder.Property(e => e.Fk_ProductId).IsRequired(true);
            builder.Property(e => e.Fk_ProductTypeId).IsRequired(true);
            builder.Property(e => e.Fk_BranchId).IsRequired(false);
            builder.Property(e => e.Rate).HasColumnType("decimal(18, 4)").HasDefaultValue(0);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasOne(lr => lr.Product).WithMany(i => i.LabourRates).HasForeignKey(lr => lr.Fk_ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(lr => lr.ProductType).WithMany(i => i.LabourRates).HasForeignKey(lr => lr.Fk_ProductTypeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(lr => lr.Branch).WithMany(i => i.LabourRates).HasForeignKey(lr => lr.Fk_BranchId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(lr => lr.FinancialYear).WithMany(i => i.LabourRates).HasForeignKey(lr => lr.Fk_FinancialYearId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
