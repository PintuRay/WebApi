using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class LedgerModel
    {
        public string LedgerName { get; set; }
        public string LedgerType { get; set; }
        public string HasSubLedger { get; set; } 
        public Guid Fk_LedgerGroupId { get; set; }
        public Guid? Fk_LedgerSubGroupId { get; set; }
    }
    public class Ledger : LedgerModel
    {
        public Guid LedgerId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public LedgerGroup LedgerGroup { get; set; }
        public LedgerSubGroup LedgerSubGroup { get; set; }

        public ICollection<SubLedger> SubLedgers { get; set; }
        public ICollection<LedgerBalance> LedgerBalances { get; set; }
        public ICollection<Party> Parties { get; set; }
        public ICollection<JournalTransaction> Journals { get; set; }
        public ICollection<PaymentTransaction> Payments { get; set; }
        public ICollection<ReceiptTransaction> Receipts { get; set; }
    }
    internal class LedgerConfig : IEntityTypeConfiguration<Ledger>
    {
        public void Configure(EntityTypeBuilder<Ledger> builder)
        {
            builder.ToTable("Ledgers", "public");
            builder.HasKey(e => e.LedgerId);
            builder.Property(e => e.LedgerId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.LedgerName).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.LedgerType).HasMaxLength(10).IsRequired(false);
            builder.Property(e => e.HasSubLedger).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.Fk_LedgerGroupId).IsRequired(true);
            builder.Property(e => e.Fk_LedgerSubGroupId).IsRequired(false);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
           builder.Property(e => e.CreatedDate).HasColumnType("timestamp").HasDefaultValueSql("CURRENT_TIMESTAMP"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamp").HasDefaultValueSql("CURRENT_TIMESTAMP"); 
            builder.HasOne(l => l.LedgerGroup).WithMany(g => g.Ledgers).HasForeignKey(l => l.Fk_LedgerGroupId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(l => l.LedgerSubGroup).WithMany(g => g.Ledgers).HasForeignKey(l => l.Fk_LedgerSubGroupId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
