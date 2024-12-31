using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class JournalTransactionModel
    {
        public string TransactionNo { get; set; } = null;
        public Guid Fk_JournalOrderId { get; set; }
        public Guid Fk_LedgerGroupId { get; set; }
        public Guid Fk_LedgerId { get; set; }
        public Guid? Fk_SubLedgerId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal Amount { get; set; }
        public string DrCr { get; set; }
    }
    public class JournalTransactionUpdateModel : JournalTransactionModel
    {
        public Guid TransactionId { get; set; }
    }
    public class JournalTransaction : JournalTransactionUpdateModel
    {
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
        public JournalOrder JournalOrder { get; set; }
    }
    public class JournalTransactionValidator : AbstractValidator<JournalTransactionModel>
    {
        public JournalTransactionValidator()
        {

        }
    }

    internal class JournalTransactionConfig : IEntityTypeConfiguration<JournalTransaction>
    {
        public void Configure(EntityTypeBuilder<JournalTransaction> builder)
        {
            builder.ToTable("JournalTransactions", "public");
            builder.HasKey(e => e.TransactionId);
            builder.Property(e => e.TransactionId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.TransactionNo).HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.Amount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.DrCr).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.Fk_LedgerGroupId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_LedgerId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_SubLedgerId).HasColumnType("uuid").IsRequired(false);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.HasOne(e => e.JournalOrder).WithMany(s => s.JournalTransactions).HasForeignKey(e => e.Fk_JournalOrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.LedgerGroup).WithMany(s => s.JournalTransactions).HasForeignKey(e => e.Fk_LedgerGroupId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Ledger).WithMany(s => s.JournalTransactions).HasForeignKey(e => e.Fk_LedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.LedgerDev).WithMany(s => s.JournalTransactions).HasForeignKey(e => e.Fk_LedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.SubLedger).WithMany(s => s.JournalTransactions).HasForeignKey(e => e.Fk_SubLedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Branch).WithMany(s => s.JournalTransactions).HasForeignKey(e => e.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.FinancialYear).WithMany(s => s.JournalTransactions).HasForeignKey(e => e.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
