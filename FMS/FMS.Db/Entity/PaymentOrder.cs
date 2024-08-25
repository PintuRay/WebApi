using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Db.Entity
{
    public class PaymentOrderModel
    {
        public string CashBank { get; set; }
        public string ChequeNo { get; set; } = null;
        public DateTime? ChequeDate { get; set; }
        public Guid? CashBankLedgerId { get; set; }
        public string VouvherNo { get; set; }
        public DateTime VoucherDate { get; set; }
        public string Narration { get; set; }
        public string DrCr { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public ICollection<PaymentTransaction> PaymentTransactions { get; set; }
    }
    public  class PaymentOrder: PaymentOrderModel
    {
        public Guid PaymentOrderId {  get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
    }
    internal class PaymentOrderConfig : IEntityTypeConfiguration<PaymentOrder>
    {
        public void Configure(EntityTypeBuilder<PaymentOrder> builder)
        {
            builder.ToTable("PaymentOrders", "dbo");
            builder.HasKey(e => e.PaymentOrderId);
            builder.Property(e => e.PaymentOrderId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.VouvherNo).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.VoucherDate).HasColumnType("datetime").IsRequired(true);
            builder.Property(e => e.ChequeNo).HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.ChequeDate).HasColumnType("datetime").IsRequired(false);
            builder.Property(e => e.CashBank).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.CashBankLedgerId).IsRequired(false);
            builder.Property(e => e.Fk_BranchId).IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).IsRequired(true);
            builder.Property(e => e.Narration).HasMaxLength(500).IsRequired(false);
            builder.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.DrCr).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasOne(e => e.Branch).WithMany(s => s.PaymentOrders).HasForeignKey(e => e.Fk_BranchId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.FinancialYear).WithMany(s => s.PaymentOrders).HasForeignKey(e => e.Fk_FinancialYearId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
