using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class JournalTransactionModel
    {
        public Guid? TransactionId { get; set; }
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
    public class JournalTransaction : JournalTransactionModel
    {
        public Guid JournalId { get; set; }
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
    internal class JournalTransactionConfig : IEntityTypeConfiguration<JournalTransaction>
    {
        public void Configure(EntityTypeBuilder<JournalTransaction> builder)
        {
            builder.ToTable("JournalTransactions", "dbo");
            builder.HasKey(e => e.JournalId);
            builder.Property(e => e.JournalId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_LedgerGroupId).IsRequired(true);
            builder.Property(e => e.Fk_LedgerId).IsRequired(true);
            builder.Property(e => e.Fk_SubLedgerId).IsRequired(false);
            builder.Property(e => e.Fk_BranchId).IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).IsRequired(true);
            builder.Property(e => e.TransactionId).IsRequired(false);
            builder.Property(e => e.TransactionNo).HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.Amount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.DrCr).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasOne(e => e.JournalOrder).WithMany(s => s.JournalTransactions).HasForeignKey(e => e.Fk_JournalOrderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.LedgerGroup).WithMany(s => s.JournalTransactions).HasForeignKey(e => e.Fk_LedgerGroupId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.SubLedger).WithMany(s => s.JournalTransactions).HasForeignKey(e => e.Fk_SubLedgerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Branch).WithMany(s => s.JournalTransactions).HasForeignKey(e => e.Fk_BranchId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.FinancialYear).WithMany(s => s.JournalTransactions).HasForeignKey(e => e.Fk_FinancialYearId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
