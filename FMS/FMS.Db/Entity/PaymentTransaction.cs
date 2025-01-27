using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class PaymentTransactionModel
    {
        [Required]
        public Guid Fk_PaymentOrderId { get; set; }
        [Required]
        public Guid Fk_LedgerGroupId { get; set; }
        [Required]
        public Guid Fk_LedgerId { get; set; }
        public Guid? Fk_SubLedgerId { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string DrCr { get; set; }
    }
    public class PaymentTransactionUpdateModel : PaymentTransactionModel
    {
        [Required]
        public Guid PaymentTransactionId { get; set; }
    }
    public class PaymentTransactionValidator : AbstractValidator<PaymentTransactionModel>
    {
        public PaymentTransactionValidator()
        {

        }
    }
    public class PaymentTransactionDto : PaymentTransactionUpdateModel
    {
        public LedgerGroup LedgerGroup { get; set; }
        public Ledger Ledger { get; set; }
        public LedgerDev LedgerDev { get; set; }
        public SubLedger SubLedger { get; set; }
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public PaymentOrder PaymentOrder { get; set; }
    }
    public class PaymentTransaction : PaymentTransactionDto
    {
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
    }
    internal class PaymentTransactionConfig : IEntityTypeConfiguration<PaymentTransaction>
    {
        public void Configure(EntityTypeBuilder<PaymentTransaction> builder)
        {
            builder.ToTable("PaymentTransactions", "public");
            builder.HasKey(e => e.PaymentTransactionId);
            builder.Property(e => e.PaymentTransactionId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_LedgerGroupId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_LedgerId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_SubLedgerId).HasColumnType("uuid").IsRequired(false);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Amount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.DrCr).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(e => e.PaymentOrder).WithMany(s => s.PaymentTransactions).HasForeignKey(e => e.Fk_PaymentOrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.LedgerGroup).WithMany(s => s.PaymentTransactions).HasForeignKey(e => e.Fk_LedgerGroupId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Ledger).WithMany(s => s.PaymentTransactions).HasForeignKey(e => e.Fk_LedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.LedgerDev).WithMany(s => s.PaymentTransactions).HasForeignKey(e => e.Fk_LedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.SubLedger).WithMany(s => s.PaymentTransactions).HasForeignKey(e => e.Fk_SubLedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Branch).WithMany(s => s.PaymentTransactions).HasForeignKey(e => e.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.FinancialYear).WithMany(s => s.PaymentTransactions).HasForeignKey(e => e.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
