using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
namespace FMS.Db.Entity
{
    public class InwardSupplyOrderModel
    {
        [Required] 
        public string TransactionNo { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public Guid FromBranch { get; set; }
        [Required]
        public Guid Fk_ProductTypeId { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public List<InwardSupplyTransactionModel> InwardSupplyTransactions { get; set; }
    }
    public class InwardSupplyOrderValidator : AbstractValidator<InwardSupplyOrderModel>
    {
        public InwardSupplyOrderValidator()
        {

        }
    }
    public class InwardSupplyOrderUpdateModel 
    {
        [Required]
        public Guid InwardSupplyOrderId { get; set; }
        [Required]
        public string TransactionNo { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public Guid FromBranch { get; set; }
        [Required]
        public Guid Fk_ProductTypeId { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public  List<InwardSupplyTransactionUpdateModel> InwardSupplyTransactions { get; set; }
    }
    public class InwardSupplyOrderUpdateValidator : AbstractValidator<InwardSupplyOrderUpdateModel>
    {
        public InwardSupplyOrderUpdateValidator()
        {

        }
    }
    public class InwardSupplyOrderDto
    {
        public Guid InwardSupplyOrderId { get; set; }
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid FromBranch { get; set; }
        public Guid Fk_ProductTypeId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<InwardSupplyTransactionDto> InwardSupplyTransactions { get; set; }
    }
    public class InwardSupplyOrder
    {
        public Guid InwardSupplyOrderId { get; set; }
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid FromBranch { get; set; }
        public Guid Fk_ProductTypeId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public ProductType ProductType { get; set; }
        public ICollection<InwardSupplyTransaction> InwardSupplyTransactions { get; set; }
    }
    internal class InwardSupplyOrderConfig : IEntityTypeConfiguration<InwardSupplyOrder>
    {
        public void Configure(EntityTypeBuilder<InwardSupplyOrder> builder)
        {
            builder.ToTable("InwardSupplyOrders", "public");
            builder.HasKey(e => e.InwardSupplyOrderId);
            builder.Property(e => e.InwardSupplyOrderId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.TransactionDate).HasColumnType("timestamptz").IsRequired(true);
            builder.Property(e => e.TransactionNo).IsRequired(true);
            builder.Property(e => e.FromBranch).IsRequired(true);
            builder.Property(e => e.Fk_ProductTypeId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(p => p.ProductType).WithMany(po => po.InwardSupplyOrders).HasForeignKey(po => po.Fk_ProductTypeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Branch).WithMany(po => po.InwardSupplyOrders).HasForeignKey(po => po.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.FinancialYear).WithMany(po => po.InwardSupplyOrders).HasForeignKey(po => po.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
