using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class PurchaseReturnTransactionModel
    {
        [Required]
        public Guid Fk_PurchaseReturnOrderId { get; set; }
        [Required]
        public Guid Fk_ProductId { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public decimal AlternateQuantity { get; set; }
        [Required]
        public Guid Fk_AlternateUnitId { get; set; }
        [Required]
        public decimal UnitQuantity { get; set; }
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public decimal DiscountAmount { get; set; }
        [Required]
        public decimal Gst { get; set; }
        [Required]
        public decimal GstAmount { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
    public class PurchaseReturnTransactionUpdateModel : PurchaseReturnTransactionModel
    {
        [Required]
        public Guid PurchaseReturnId { get; }
    }
    public class PurchaseReturnTransactionValidator : AbstractValidator<PurchaseReturnTransactionModel>
    {
        public PurchaseReturnTransactionValidator()
        {

        }
    }
    public class PurchaseReturnTransactionDto : PurchaseReturnTransactionUpdateModel
    {
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public PurchaseReturnOrder PurchaseReturnOrder { get; set; }
        public Product Product { get; set; }
        public AlternateUnit AlternateUnit { get; set; }
    }
    public class PurchaseReturnTransaction : PurchaseReturnTransactionDto
    {
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
    }

    internal class PurchaseReturnTransactionConfig : IEntityTypeConfiguration<PurchaseReturnTransaction>
    {
        public void Configure(EntityTypeBuilder<PurchaseReturnTransaction> builder)
        {
            builder.ToTable("PurchaseReturnTransactions", "public");
            builder.HasKey(e => e.PurchaseReturnId);
            builder.Property(e => e.PurchaseReturnId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_PurchaseReturnOrderId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_ProductId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_AlternateUnitId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.AlternateQuantity).HasColumnType("decimal(18, 5)").HasDefaultValue(0);
            builder.Property(e => e.UnitQuantity).HasColumnType("decimal(18, 5)").HasDefaultValue(0);
            builder.Property(e => e.Rate).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.Discount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.Gst).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.GstAmount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.Amount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(p => p.PurchaseReturnOrder).WithMany(po => po.PurchaseReturnTransactions).HasForeignKey(po => po.Fk_PurchaseReturnOrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.AlternateUnit).WithMany(po => po.PurchaseReturnTransactions).HasForeignKey(po => po.Fk_AlternateUnitId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Product).WithMany(po => po.PurchaseReturnTransactions).HasForeignKey(po => po.Fk_ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Branch).WithMany(po => po.PurchaseReturnTransactions).HasForeignKey(po => po.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.FinancialYear).WithMany(po => po.PurchaseReturnTransactions).HasForeignKey(po => po.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
