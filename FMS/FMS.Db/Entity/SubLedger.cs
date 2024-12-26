﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class SubLedgerModel
    {
        public Guid Fk_LedgerId { get; set; }
        public Guid? Fk_BranchId { get; set; }
        public string SubLedgerName { get; set; }
    }
    public class SubLedger : SubLedgerModel
    {
        public Guid SubLedgerId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Ledger Ledger { get; set; }
        public LedgerDev LedgerDev { get; set; }
        public Branch Branch { get; set; }
        public ICollection<SubLedgerBalance> SubLedgerBalances { get; set; }
        public ICollection<Labour> Labours { get; set; }
        public ICollection<Party> Parties { get; set; }
        public ICollection<JournalTransaction> JournalTransactions { get; set; }
        public ICollection<PaymentTransaction> PaymentTransaction { get; set; }
        public ICollection<ReceiptTransaction> ReceiptTransactions { get; set; }
        public ICollection<SalesOrder> SalesOrders { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public ICollection<SalesReturnOrder> SalesReturnOrders { get; set; }
        public ICollection<PurchaseReturnOrder> PurchaseReturnOrders { get; set; }
    }
    internal class SubLedgerConfig : IEntityTypeConfiguration<SubLedger>
    {
        public void Configure(EntityTypeBuilder<SubLedger> builder)
        {
            builder.ToTable("SubLedgers", "public");
            builder.HasKey(e => e.SubLedgerId);
            builder.Property(e => e.SubLedgerId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.SubLedgerName).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.Fk_BranchId).IsRequired(false);
            builder.Property(e => e.Fk_LedgerId).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
                       builder.Property(e => e.CreatedDate).HasColumnType("timestamp").HasDefaultValueSql("CURRENT_TIMESTAMP"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamp").HasDefaultValueSql("CURRENT_TIMESTAMP"); 
            builder.HasOne(bs => bs.Branch).WithMany(b => b.SubLedgers).HasForeignKey(bs => bs.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
