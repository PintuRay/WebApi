using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class SalesTransactionModel
    {
        [Required]
        public Guid Fk_SalesOrderId { get; set; }
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
    public class SalesTransactionValidator : AbstractValidator<SalesTransactionModel>
    {
        public SalesTransactionValidator()
        {

        }
    }
    public class SalesTransactionUpdateModel
    {
        [Required]
        public Guid SalesId { get; }
        [Required]
        public Guid Fk_SalesOrderId { get; set; }
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
    public class SalesTransactionUpdateValidator : AbstractValidator<SalesTransactionUpdateModel>
    {
        public SalesTransactionUpdateValidator()
        {

        }
    }
    public class SalesTransactionDto
    {
        public Guid SalesId { get; }
        public Guid Fk_SalesOrderId { get; set; }
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
    public class SalesTransaction
    {
        public Guid SalesId { get; }
        public Guid Fk_SalesOrderId { get; set; }
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
        public SalesOrder SalesOrder { get; set; }
        public Product Product { get; set; }
        public AlternateUnit AlternateUnit { get; set; }
    }
    internal class SalesTransactionConfig : IEntityTypeConfiguration<SalesTransaction>
    {
        public void Configure(EntityTypeBuilder<SalesTransaction> builder)
        {
            builder.ToTable("SalesTransaction", "public");
            builder.HasKey(e => e.SalesId);
            builder.Property(e => e.SalesId).ValueGeneratedOnAdd().HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_SalesOrderId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_ProductId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Quantity).HasColumnType("decimal(18,5)").IsRequired(true);
            builder.Property(e => e.Fk_AlternateUnitId).HasColumnType("uuid").IsRequired(true);
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
            builder.HasOne(p => p.SalesOrder).WithMany(po => po.SalesTransactions).HasForeignKey(po => po.Fk_SalesOrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Product).WithMany(po => po.SalesTransactions).HasForeignKey(po => po.Fk_ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.AlternateUnit).WithMany(s => s.SalesTransactions).HasForeignKey(e => e.Fk_AlternateUnitId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Branch).WithMany(po => po.SalesTransactions).HasForeignKey(po => po.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.FinancialYear).WithMany(po => po.SalesTransactions).HasForeignKey(po => po.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
