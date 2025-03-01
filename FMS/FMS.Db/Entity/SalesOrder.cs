using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class SalesOrderModel
    {
        [Required]
        public string TransactionNo { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public string TransactionType { get; set; }
        [Required]
        public string PriceType { get; set; }
        public Guid? Fk_SubLedgerId { get; set; }
        public string CustomerName { get; set; } = null;
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public string OrderNo { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public decimal SubTotal { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public decimal Gst { get; set; }
        [Required]
        public decimal GrandTotal { get; set; }
        [Required]
        public string TranspoterName { get; set; }
        public string VehicleNo { get; set; } = null;
        public string ReceivingPerson { get; set; } = null;
        public string Narration { get; set; } = null;
        public List<SalesTransactionModel> SalesTransactions { get; set; }
    }
    public class SalesOrderValidator : AbstractValidator<SalesOrderModel>
    {
        public SalesOrderValidator()
        {

        }
    }
    public class SalesOrderUpdateModel
    {
        [Required]
        public Guid SalesOrderId { get; set; }
        [Required]
        public string TransactionNo { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public string TransactionType { get; set; }
        [Required]
        public string PriceType { get; set; }
        public Guid? Fk_SubLedgerId { get; set; }
        public string CustomerName { get; set; } = null;
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public string OrderNo { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public decimal SubTotal { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public decimal Gst { get; set; }
        [Required]
        public decimal GrandTotal { get; set; }
        [Required]
        public string TranspoterName { get; set; }
        public string VehicleNo { get; set; } = null;
        public string ReceivingPerson { get; set; } = null;
        public string Narration { get; set; } = null;
        public List<SalesTransactionUpdateModel> SalesTransactions { get; set; }
    }
    public class SalesOrderUpdateValidator : AbstractValidator<SalesOrderUpdateModel>
    {
        public SalesOrderUpdateValidator()
        {

        }
    }
    public class SalesOrderDto
    {
        public Guid SalesOrderId { get; set; }
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public string PriceType { get; set; }
        public Guid? Fk_SubLedgerId { get; set; }
        public string CustomerName { get; set; } = null;
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Gst { get; set; }
        public decimal GrandTotal { get; set; }
        public string TranspoterName { get; set; }
        public string VehicleNo { get; set; } = null;
        public string ReceivingPerson { get; set; } = null;
        public string Narration { get; set; } = null;
        public List<SalesTransactionDto> SalesTransactions { get; set; }
    }
    public class SalesOrder
    {
        public Guid SalesOrderId { get; set; }
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public string PriceType { get; set; }
        public Guid? Fk_SubLedgerId { get; set; }
        public string CustomerName { get; set; } = null;
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal Gst { get; set; }
        public decimal GrandTotal { get; set; }
        public string TranspoterName { get; set; }
        public string VehicleNo { get; set; } = null;
        public string ReceivingPerson { get; set; } = null;
        public string Narration { get; set; } = null;
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public SubLedger SubLedger { get; set; }
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }
    }
    internal class SalesOrderConfig : IEntityTypeConfiguration<SalesOrder>
    {
        public void Configure(EntityTypeBuilder<SalesOrder> builder)
        {
            builder.ToTable("SalesOrders", "public");
            builder.HasKey(e => e.SalesOrderId);
            builder.Property(e => e.SalesOrderId).ValueGeneratedOnAdd().HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.TransactionNo).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.TransactionType).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.PriceType).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.Fk_SubLedgerId).HasColumnType("uuid").IsRequired(false);
            builder.Property(e => e.CustomerName).HasMaxLength(200).IsRequired(false);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.TransactionDate).HasColumnType("timestamptz").IsRequired(true);
            builder.Property(e => e.OrderNo).HasMaxLength(200).IsRequired(true);
            builder.Property(e => e.OrderDate).HasColumnType("timestamptz").IsRequired(true);
            builder.Property(e => e.VehicleNo).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.ReceivingPerson).HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.TranspoterName).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.Narration).HasMaxLength(500).IsRequired(false);
            builder.Property(e => e.SubTotal).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.Discount).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.Gst).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.GrandTotal).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(e => e.SubLedger).WithMany(s => s.SalesOrders).HasForeignKey(e => e.Fk_SubLedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Branch).WithMany(po => po.SalesOrders).HasForeignKey(po => po.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.FinancialYear).WithMany(po => po.SalesOrders).HasForeignKey(po => po.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
