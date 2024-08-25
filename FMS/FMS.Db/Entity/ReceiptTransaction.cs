using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FMS.Db.Entity
{
    public class ReceiptTransactionModel
    {    
        public Guid Fk_ReceiptOrderId {  get; set; }
        public Guid Fk_LedgerGroupId { get; set; }
        public Guid Fk_LedgerId { get; set; }
        public Guid? Fk_SubLedgerId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal Amount { get; set; }
        public string DrCr { get; set; }
    }
    public class ReceiptTransaction : ReceiptTransactionModel
    {
        public Guid ReceiptId { get; set; }
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
            builder.ToTable("ReceiptTransactions", "dbo");
            builder.HasKey(e => e.ReceiptId);
            builder.Property(e => e.ReceiptId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_LedgerGroupId).IsRequired(true);
            builder.Property(e => e.Fk_LedgerId).IsRequired(true);
            builder.Property(e => e.Fk_SubLedgerId).IsRequired(false);
            builder.Property(e => e.Fk_BranchId).IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).IsRequired(true);
            builder.Property(e => e.Amount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.DrCr).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasOne(e => e.ReceiptOrder).WithMany(s => s.ReceiptTransactions).HasForeignKey(e => e.Fk_ReceiptOrderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.LedgerGroup).WithMany(s => s.ReceiptTransactions).HasForeignKey(e => e.Fk_LedgerGroupId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.SubLedger).WithMany(s => s.ReceiptTransactions).HasForeignKey(e => e.Fk_SubLedgerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Branch).WithMany(s => s.ReceiptTransactions).HasForeignKey(e => e.Fk_BranchId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.FinancialYear).WithMany(s => s.ReceiptTransactions).HasForeignKey(e => e.Fk_FinancialYearId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
