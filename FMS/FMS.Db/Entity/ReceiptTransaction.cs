using FluentValidation;
using FMS.Db.CustomVaidator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class ReceiptTransactionModel
    {
        [Required]
        public Guid Fk_ReceiptOrderId { get; set; }
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
    public class ReceiptTransactionValidator : AbstractValidator<ReceiptTransactionModel>
    {
        public ReceiptTransactionValidator(CustomValidation vaidator)
        {

        }
    }
    public class ReceiptTransactionUpdateModel
    {
        [Required]
        public Guid ReceiptTransactiontId { get; set; }
        [Required]
        public Guid Fk_ReceiptOrderId { get; set; }
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
    public class ReceiptTransactionUpdateValidator : AbstractValidator<ReceiptTransactionUpdateModel>
    {
        public ReceiptTransactionUpdateValidator(CustomValidation vaidator)
        {

        }
    }
    public class ReceiptTransactionDto
    {
        public Guid ReceiptTransactiontId { get; set; }
        public Guid Fk_ReceiptOrderId { get; set; }
        public Guid Fk_LedgerGroupId { get; set; }
        public Guid Fk_LedgerId { get; set; }
        public Guid? Fk_SubLedgerId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal Amount { get; set; }
        public string DrCr { get; set; }
    }
    public class ReceiptTransaction
    {
        public Guid ReceiptTransactiontId { get; set; }
        public Guid Fk_ReceiptOrderId { get; set; }
        public Guid Fk_LedgerGroupId { get; set; }
        public Guid Fk_LedgerId { get; set; }
        public Guid? Fk_SubLedgerId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal Amount { get; set; }
        public string DrCr { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public LedgerGroup LedgerGroup { get; set; }
        public Ledger Ledger { get; set; }
        public LedgerDev LedgerDev { get; set; }
        public SubLedger SubLedger { get; set; }
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public ReceiptOrder ReceiptOrder { get; set; }
    }
    internal class ReceiptTransactionConfig : IEntityTypeConfiguration<ReceiptTransaction>
    {
        public void Configure(EntityTypeBuilder<ReceiptTransaction> builder)
        {
            builder.ToTable("ReceiptTransactions", "public");
            builder.HasKey(e => e.ReceiptTransactiontId);
            builder.Property(e => e.ReceiptTransactiontId).HasDefaultValueSql("gen_random_uuid()");
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
            builder.HasOne(e => e.ReceiptOrder).WithMany(s => s.ReceiptTransactions).HasForeignKey(e => e.Fk_ReceiptOrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.LedgerGroup).WithMany(s => s.ReceiptTransactions).HasForeignKey(e => e.Fk_LedgerGroupId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Ledger).WithMany(s => s.ReceiptTransactions).HasForeignKey(e => e.Fk_LedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.LedgerDev).WithMany(s => s.ReceiptTransactions).HasForeignKey(e => e.Fk_LedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.SubLedger).WithMany(s => s.ReceiptTransactions).HasForeignKey(e => e.Fk_SubLedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Branch).WithMany(s => s.ReceiptTransactions).HasForeignKey(e => e.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.FinancialYear).WithMany(s => s.ReceiptTransactions).HasForeignKey(e => e.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
