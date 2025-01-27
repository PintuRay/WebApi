using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
namespace FMS.Db.Entity
{
    public class InwardSupplyTransactionModel
    {
        [Required]
        public Guid Fk_InwardSupplyOrderId { get; set; }
        [Required]
        public Guid Fk_ProductId { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public Guid Fk_UnitId {  get; set; }
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }
    public class InwardSupplyTransactionUpdateModel : InwardSupplyTransactionModel
    {
        [Required]
        public Guid InwardSupplyTransactionId { get; set; }
    }
    public class InwardSupplyTransactionValidator : AbstractValidator<InwardSupplyTransactionModel>
    {
        public InwardSupplyTransactionValidator()
        {

        }
    }
    public class InwardSupplyTransactionDto: InwardSupplyTransactionUpdateModel
    {
        public InwardSupplyOrder InwardSupplyOrder { get; set; }
        public Product Product { get; set; }
        public Unit Unit { get; set; }
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
    }
    public class InwardSupplyTransaction : InwardSupplyTransactionDto
    {
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
    }
    internal class InwardSupplyTransactionConfig : IEntityTypeConfiguration<InwardSupplyTransaction>
    {
        public void Configure(EntityTypeBuilder<InwardSupplyTransaction> builder)
        {
            builder.ToTable("InwardSupplyTransactions", "public");
            builder.HasKey(e => e.InwardSupplyTransactionId);
            builder.Property(e => e.InwardSupplyTransactionId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_InwardSupplyOrderId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_ProductId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Quantity).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.Rate).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.Amount).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.HasOne(p => p.InwardSupplyOrder).WithMany(po => po.InwardSupplyTransactions).HasForeignKey(po => po.Fk_InwardSupplyOrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Product).WithMany(po => po.InwardSupplyTransactions).HasForeignKey(po => po.Fk_ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Branch).WithMany(po => po.InwardSupplyTransactions).HasForeignKey(po => po.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.FinancialYear).WithMany(po => po.InwardSupplyTransactions).HasForeignKey(po => po.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
