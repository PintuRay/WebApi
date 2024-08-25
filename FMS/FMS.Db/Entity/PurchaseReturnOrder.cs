using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FMS.Db.Entity
{
    public class PurchaseReturnOrderModel
    {
        public Guid Fk_ProductTypeId { get; set; }
        public string TransactionNo { get; set; }
        public Guid Fk_SubLedgerId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TransportationCharges { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Gst { get; set; }
        public string TranspoterName { get; set; }
        public string VehicleNo { get; set; } = null;
        public string ReceivingPerson { get; set; } = null;
        public string Narration { get; set; } = null;
        public ICollection<PurchaseReturnTransaction> PurchaseReturnTransactions { get; set; }
    }
    public class PurchaseReturnOrder : PurchaseReturnOrderModel
    {
        public Guid PurchaseReturnOrderId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public SubLedger SubLedger { get; set; }
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public ProductType ProductType { get; set; }

    }
    internal class PurchaseReturnOrderConfig : IEntityTypeConfiguration<PurchaseReturnOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseReturnOrder> builder)
        {
            builder.ToTable("PurchaseReturnOrders", "dbo");
            builder.HasKey(e => e.PurchaseReturnOrderId);
            builder.Property(e => e.PurchaseReturnOrderId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_ProductTypeId).IsRequired(true);
            builder.Property(e => e.Fk_SubLedgerId).IsRequired(true);
            builder.Property(e => e.Fk_BranchId).IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).IsRequired(true);
            builder.Property(e => e.TransactionNo).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.TransactionDate).HasColumnType("datetime").IsRequired(true);
            builder.Property(e => e.InvoiceNo).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.InvoiceDate).HasColumnType("datetime").IsRequired(true);
            builder.Property(e => e.TransportationCharges).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(e => e.TranspoterName).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.ReceivingPerson).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.VehicleNo).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.Narration).HasMaxLength(500).IsRequired(false);
            builder.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.Discount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.Gst).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.GrandTotal).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasOne(e => e.SubLedger).WithMany(s => s.PurchaseReturnOrders).HasForeignKey(e => e.Fk_SubLedgerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.ProductType).WithMany(s => s.PurchaseReturnOrders).HasForeignKey(e => e.Fk_ProductTypeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Branch).WithMany(s => s.PurchaseReturnOrders).HasForeignKey(e => e.Fk_BranchId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.FinancialYear).WithMany(s => s.PurchaseReturnOrders).HasForeignKey(e => e.Fk_FinancialYearId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
