using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Db.Entity
{
    public class ProductionTransactionModel
    {
        public Guid Fk_ProductionOrderId {  get; set; }
        public Guid Fk_RawMaterialId { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
    public class ProductionTransactionUpdateModel : ProductionTransactionModel
    {
        public Guid ProductionTransactionId { get; set; }
    }
    public class ProductionTransaction: ProductionTransactionUpdateModel
    {
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public ProductionOrder ProductionOrder { get; set; }
        [NotMapped]
        public string RawMaterialName { get; set; }

        public Product Product { get; set; }
    }
    public class ProductionTransactionValidator : AbstractValidator<ProductionTransactionModel>
    {
        public ProductionTransactionValidator()
        {

        }
    }
    internal class ProductionTransactionConfig : IEntityTypeConfiguration<ProductionTransaction>
    {
        public void Configure(EntityTypeBuilder<ProductionTransaction> builder)
        {
            builder.ToTable("ProductionTransactions", "public");
            builder.HasKey(e => e.ProductionTransactionId);
            builder.Property(e => e.ProductionTransactionId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_RawMaterialId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.Quantity).HasColumnType("decimal(18, 5)").IsRequired(true);
            builder.Property(e => e.Unit).HasMaxLength(100).IsRequired(true);
            builder.HasOne(e => e.ProductionOrder).WithMany(s => s.ProductionTransactions).HasForeignKey(e => e.Fk_ProductionOrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Product).WithMany(s => s.ProductionTransactions).HasForeignKey(e => e.Fk_RawMaterialId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
