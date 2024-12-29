using FluentValidation;
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

    public class LabourRateUpdateModel : LabourRateModel
    {
        public Guid LabourRateId { get; set; }
    }
    public class LabourRate : LabourRateUpdateModel
    {
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public ProductType ProductType { get; set; }
        public Product Product { get; set; }
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
    }
    public class LabourRateValidator : AbstractValidator<LabourRateModel>
    {
        public LabourRateValidator()
        {

        }
    }
    internal class LabourRateConfig : IEntityTypeConfiguration<LabourRate>
    {
        public void Configure(EntityTypeBuilder<LabourRate> builder)
        {
            builder.ToTable("LabourRates", "public");
            builder.HasKey(e => e.LabourRateId);
            builder.Property(e => e.LabourRateId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Date).HasColumnType("timestamptz").IsRequired(true);
            builder.Property(e => e.Fk_ProductId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_ProductTypeId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(false);
            builder.Property(e => e.Rate).HasColumnType("decimal(18, 4)").HasDefaultValue(0.00);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.HasOne(lr => lr.Product).WithMany(i => i.LabourRates).HasForeignKey(lr => lr.Fk_ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(lr => lr.ProductType).WithMany(i => i.LabourRates).HasForeignKey(lr => lr.Fk_ProductTypeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(lr => lr.Branch).WithMany(i => i.LabourRates).HasForeignKey(lr => lr.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(lr => lr.FinancialYear).WithMany(i => i.LabourRates).HasForeignKey(lr => lr.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
