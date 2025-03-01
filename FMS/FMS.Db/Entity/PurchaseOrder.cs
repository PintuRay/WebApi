using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Db.Entity
{
    public class PurchaseOrderModel
    {
        [Required]
        public string TransactionNo { get; set; }
        [Required]
        public Guid Fk_ProductTypeId { get; set; }
        [Required]
        public Guid Fk_SubLedgerId { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public string InvoiceNo { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public decimal SubTotal { get; set; }
        [Required]
        public decimal Discount { get; set; }

        public decimal? Gst { get; set; }
        [Required]
        public decimal TransportationCharges { get; set; }
        [Required]
        public decimal GrandTotal { get; set; }
        [Required]
        public string TranspoterName { get; set; }
        public string VehicleNo { get; set; } = null;
        public string Narration { get; set; } = null;
        public string ReceivingPerson { get; set; } = null;
        public List<PurchaseTransactionModel> PurchaseTransactions { get; set; }
    }
    public class PurchaseOrderValidator : AbstractValidator<PurchaseOrderModel>
    {
        public PurchaseOrderValidator()
        {

        }
    }
    public class PurchaseOrderUpdateModel
    {
        public Guid PurchaseOrderId { get; set; }
        [Required]
        public string TransactionNo { get; set; }
        [Required]
        public Guid Fk_ProductTypeId { get; set; }
        [Required]
        public Guid Fk_SubLedgerId { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public string InvoiceNo { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public decimal SubTotal { get; set; }
        [Required]
        public decimal Discount { get; set; }
        public decimal? Gst { get; set; }
        [Required]
        public decimal TransportationCharges { get; set; }
        [Required]
        public decimal GrandTotal { get; set; }
        [Required]
        public string TranspoterName { get; set; }
        public string VehicleNo { get; set; } = null;
        public string Narration { get; set; } = null;
        public string ReceivingPerson { get; set; } = null;
        public List<PurchaseTransactionUpdateModel> PurchaseTransactions { get; set; }
    }
    public class PurchaseOrderUpdateValidator : AbstractValidator<PurchaseOrderUpdateModel>
    {
        public PurchaseOrderUpdateValidator()
        {

        }
    }
    public class PurchaseOrderDto
    {
        public Guid PurchaseOrderId { get; set; }
        public string TransactionNo { get; set; }
        public Guid Fk_ProductTypeId { get; set; }
        public Guid Fk_SubLedgerId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal? Gst { get; set; }
        public decimal TransportationCharges { get; set; }
        public decimal GrandTotal { get; set; }
        public string TranspoterName { get; set; }
        public string VehicleNo { get; set; } = null;
        public string Narration { get; set; } = null;
        public string ReceivingPerson { get; set; } = null;
        public List<PurchaseTransactionDto> PurchaseTransactions { get; set; }
    }
    public class PurchaseOrder
    {
        public Guid PurchaseOrderId { get; set; }
        public string TransactionNo { get; set; }
        public Guid Fk_ProductTypeId { get; set; }
        public Guid Fk_SubLedgerId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal? Gst { get; set; }
        public decimal TransportationCharges { get; set; }
        public decimal GrandTotal { get; set; }
        public string TranspoterName { get; set; }
        public string VehicleNo { get; set; } = null;
        public string Narration { get; set; } = null;
        public string ReceivingPerson { get; set; } = null;
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public SubLedger SubLedger { get; set; }
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public ProductType ProductType { get; set; }
        public ICollection<PurchaseTransaction> PurchaseTransactions { get; set; }
    }
    internal class PurchaseOrderConfig : IEntityTypeConfiguration<PurchaseOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
        {
            builder.ToTable("PurchaseOrders", "public");
            builder.HasKey(e => e.PurchaseOrderId);
            builder.Property(e => e.PurchaseOrderId).ValueGeneratedOnAdd().HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.TransactionNo).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.Fk_ProductTypeId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_SubLedgerId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.TransactionDate).HasColumnType("timestamptz").IsRequired(true);
            builder.Property(e => e.InvoiceNo).HasMaxLength(200).IsRequired(true);
            builder.Property(e => e.InvoiceDate).HasColumnType("timestamptz").IsRequired(true);
            builder.Property(e => e.VehicleNo).HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.TranspoterName).HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.ReceivingPerson).HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.Narration).HasMaxLength(500).IsRequired(false);
            builder.Property(e => e.SubTotal).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.Discount).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.Gst).HasColumnType("decimal(18,2)").IsRequired(false);
            builder.Property(e => e.TransportationCharges).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(e => e.GrandTotal).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(e => e.SubLedger).WithMany(s => s.PurchaseOrders).HasForeignKey(e => e.Fk_SubLedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.ProductType).WithMany(s => s.PurchaseOrders).HasForeignKey(e => e.Fk_ProductTypeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Branch).WithMany(po => po.PurchaseOrders).HasForeignKey(po => po.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.FinancialYear).WithMany(po => po.PurchaseOrders).HasForeignKey(po => po.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
