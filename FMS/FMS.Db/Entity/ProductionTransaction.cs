using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class ProductionTransactionModel
    {
        [Required]
        public Guid Fk_ProductionOrderId { get; set; }
        [Required]
        public Guid Fk_ProductId { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public Guid Fk_AlternateUnitId { get; set; }
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
    }
    public class ProductionTransactionUpdateModel : ProductionTransactionModel
    {
        [Required]
        public Guid ProductionTransactionId { get; set; }
    }
    public class ProductionTransactionValidator : AbstractValidator<ProductionTransactionModel>
    {
        public ProductionTransactionValidator()
        {

        }
    }
    public class ProductionTransactionDto : ProductionTransactionUpdateModel
    {
        public ProductionOrder ProductionOrder { get; set; }
        public Product Product { get; set; }
        public AlternateUnit AlternateUnit { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public Branch Branch { get; set; }
    }
    public class ProductionTransaction : ProductionTransactionDto
    {
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
    }
    internal class LabourTransactionConfig : IEntityTypeConfiguration<ProductionTransaction>
    {
        public void Configure(EntityTypeBuilder<ProductionTransaction> builder)
        {
            builder.ToTable("LabourTransactions", "public");
            builder.HasKey(e => e.ProductionTransactionId);
            builder.Property(e => e.ProductionTransactionId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_ProductionOrderId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_ProductId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Quantity).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.Fk_AlternateUnitId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Rate).HasColumnType("decimal(18, 4)").HasDefaultValue(0);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(s => s.ProductionOrder).WithMany(pe => pe.ProductionTransactions).HasForeignKey(e => e.Fk_ProductionOrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.Product).WithMany(pe => pe.ProductionTransactions).HasForeignKey(e => e.Fk_ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.FinancialYear).WithMany(pe => pe.ProductionTransactions).HasForeignKey(e => e.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.Branch).WithMany(pe => pe.ProductionTransactions).HasForeignKey(e => e.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.AlternateUnit).WithMany(s => s.ProductionTransactions).HasForeignKey(e => e.Fk_AlternateUnitId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
