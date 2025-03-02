using FluentValidation;
using FMS.Db.CustomVaidator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Db.Entity
{
    public class PurchaseReturnOrderModel
    {
        [Required]
        public Guid Fk_ProductTypeId { get; set; }
        [Required]
        public string TransactionNo { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public string InvoiceNo { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public Guid Fk_SubLedgerId { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public string TranspoterName { get; set; }
        public string VehicleNo { get; set; } = null;
        public string ReceivingPerson { get; set; } = null;
        [Required]
        public decimal TransportationCharges { get; set; }
        [Required]
        public decimal SubTotal { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public decimal GrandTotal { get; set; }
        [Required]
        public decimal Gst { get; set; }
        public string Narration { get; set; } = null;
        public ICollection<PurchaseReturnTransactionModel> PurchaseReturnTransactions { get; set; }
    }
    public class PurchaseReturnOrderValidator : AbstractValidator<PurchaseReturnOrderModel>
    {
        public PurchaseReturnOrderValidator(CustomValidation vaidator)
        {

        }
    }
    public class PurchaseReturnOrderUpdateModel
    {
        [Required]
        public Guid PurchaseReturnOrderId { get; set; }
        [Required]
        public Guid Fk_ProductTypeId { get; set; }
        [Required]
        public string TransactionNo { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public string InvoiceNo { get; set; }
        [Required]
        public DateTime InvoiceDate { get; set; }
        [Required]
        public Guid Fk_SubLedgerId { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public string TranspoterName { get; set; }
        public string VehicleNo { get; set; } = null;
        public string ReceivingPerson { get; set; } = null;
        [Required]
        public decimal TransportationCharges { get; set; }
        [Required]
        public decimal SubTotal { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public decimal GrandTotal { get; set; }
        [Required]
        public decimal Gst { get; set; }
        public string Narration { get; set; } = null;
        public  List<PurchaseReturnTransactionUpdateModel> PurchaseReturnTransactions { get; set; }
    }
    public class PurchaseReturnOrderUpdateValidator : AbstractValidator<PurchaseReturnOrderUpdateModel>
    {
        public PurchaseReturnOrderUpdateValidator(CustomValidation vaidator)
        {

        }
    }
    public class PurchaseReturnOrderDto
    {
        public Guid PurchaseReturnOrderId { get; set; }
        public Guid Fk_ProductTypeId { get; set; }
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid Fk_SubLedgerId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public string TranspoterName { get; set; }
        public string VehicleNo { get; set; } = null;
        public string ReceivingPerson { get; set; } = null;
        public decimal TransportationCharges { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Gst { get; set; }
        public string Narration { get; set; } = null;
        public List<PurchaseReturnTransactionDto> PurchaseReturnTransactions { get; set; }
    }
    public class PurchaseReturnOrder
    {
        public Guid PurchaseReturnOrderId { get; set; }
        public Guid Fk_ProductTypeId { get; set; }
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Guid Fk_SubLedgerId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public string TranspoterName { get; set; }
        public string VehicleNo { get; set; } = null;
        public string ReceivingPerson { get; set; } = null;
        public decimal TransportationCharges { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal Gst { get; set; }
        public string Narration { get; set; } = null;
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public SubLedger SubLedger { get; set; }
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public ProductType ProductType { get; set; }
        public ICollection<PurchaseReturnTransaction> PurchaseReturnTransactions { get; set; }
    }
    internal class PurchaseReturnOrderConfig : IEntityTypeConfiguration<PurchaseReturnOrder>
    {
        public void Configure(EntityTypeBuilder<PurchaseReturnOrder> builder)
        {
            builder.ToTable("PurchaseReturnOrders", "public");
            builder.HasKey(e => e.PurchaseReturnOrderId);
            builder.Property(e => e.PurchaseReturnOrderId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_ProductTypeId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_SubLedgerId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.TransactionNo).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.TransactionDate).HasColumnType("timestamptz").IsRequired(true);
            builder.Property(e => e.InvoiceNo).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.InvoiceDate).HasColumnType("timestamptz").IsRequired(true);
            builder.Property(e => e.TransportationCharges).HasColumnType("decimal(18,2)").HasDefaultValue(0);
            builder.Property(e => e.TranspoterName).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.ReceivingPerson).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.VehicleNo).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.Narration).HasMaxLength(500).IsRequired(false);
            builder.Property(e => e.SubTotal).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.Discount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.Gst).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.GrandTotal).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(e => e.SubLedger).WithMany(s => s.PurchaseReturnOrders).HasForeignKey(e => e.Fk_SubLedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.ProductType).WithMany(s => s.PurchaseReturnOrders).HasForeignKey(e => e.Fk_ProductTypeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Branch).WithMany(s => s.PurchaseReturnOrders).HasForeignKey(e => e.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.FinancialYear).WithMany(s => s.PurchaseReturnOrders).HasForeignKey(e => e.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
