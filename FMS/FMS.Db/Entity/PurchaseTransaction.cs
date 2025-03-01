using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class PurchaseTransactionModel
    {
        [Required]
        public Guid Fk_PurchaseOrderId { get; set; }
        [Required]
        public Guid Fk_ProductId { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public Guid Fk_AlternateUnitId { get; set; }
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
    public class PurchaseTransactionValidator : AbstractValidator<PurchaseTransactionModel>
    {
        public PurchaseTransactionValidator()
        {

        }
    }
    public class PurchaseTransactionUpdateModel
    {
        [Required]
        public Guid PurchaseId { get; }
        [Required]
        public Guid Fk_PurchaseOrderId { get; set; }
        [Required]
        public Guid Fk_ProductId { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public Guid Fk_AlternateUnitId { get; set; }
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
    public class PurchaseTransactionUpdateValidator : AbstractValidator<PurchaseTransactionUpdateModel>
    {
        public PurchaseTransactionUpdateValidator()
        {

        }
    }
    public class PurchaseTransactionDto
    {
        public Guid PurchaseId { get; }
        public Guid Fk_PurchaseOrderId { get; set; }
        public Guid Fk_ProductId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal Quantity { get; set; }
        public Guid Fk_AlternateUnitId { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal Gst { get; set; }
        public decimal GstAmount { get; set; }
        public decimal Amount { get; set; }
    }
    public class PurchaseTransaction
    {
        public Guid PurchaseId { get; }
        public Guid Fk_PurchaseOrderId { get; set; }
        public Guid Fk_ProductId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal Quantity { get; set; }
        public Guid Fk_AlternateUnitId { get; set; }
        public decimal Rate { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal Gst { get; set; }
        public decimal GstAmount { get; set; }
        public decimal Amount { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public Product Product { get; set; }
        public AlternateUnit AlternateUnit { get; set; }
    }
    internal class PurchaseTransactionConfig : IEntityTypeConfiguration<PurchaseTransaction>
    {
        public void Configure(EntityTypeBuilder<PurchaseTransaction> builder)
        {
            builder.ToTable("PurchaseTransactions", "public");
            builder.HasKey(e => e.PurchaseId);
            builder.Property(e => e.PurchaseId).ValueGeneratedOnAdd().HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_PurchaseOrderId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_AlternateUnitId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_ProductId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Quantity).HasColumnType("decimal(18,5)").IsRequired(true);
            builder.Property(e => e.Rate).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.Discount).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.DiscountAmount).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.Gst).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.GstAmount).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.Amount).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(p => p.PurchaseOrder).WithMany(po => po.PurchaseTransactions).HasForeignKey(po => po.Fk_PurchaseOrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.AlternateUnit).WithMany(po => po.PurchaseTransactions).HasForeignKey(po => po.Fk_AlternateUnitId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Product).WithMany(po => po.PurchaseTransactions).HasForeignKey(po => po.Fk_ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Branch).WithMany(po => po.PurchaseTransactions).HasForeignKey(po => po.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.FinancialYear).WithMany(po => po.PurchaseTransactions).HasForeignKey(po => po.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
