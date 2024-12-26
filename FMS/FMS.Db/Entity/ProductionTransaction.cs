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
    public class ProductionTransaction: ProductionTransactionModel
    {
        public Guid ProductionTransactionId {  get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public ProductionOrder ProductionOrder { get; set; }
        [NotMapped]
        public string RawMaterialName { get; set; }
    }
    internal class ProductionTransactionConfig : IEntityTypeConfiguration<ProductionTransaction>
    {
        public void Configure(EntityTypeBuilder<ProductionTransaction> builder)
        {
            builder.ToTable("ProductionTransactions", "public");
            builder.HasKey(e => e.ProductionTransactionId);
            builder.Property(e => e.ProductionTransactionId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_RawMaterialId).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
                       builder.Property(e => e.CreatedDate).HasColumnType("timestamp").HasDefaultValueSql("CURRENT_TIMESTAMP"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamp").HasDefaultValueSql("CURRENT_TIMESTAMP"); 
            builder.Property(e => e.Quantity).HasColumnType("decimal(18, 5)").IsRequired(true);
            builder.Property(e => e.Unit).HasMaxLength(100).IsRequired(true);
            builder.HasOne(e => e.ProductionOrder).WithMany(s => s.ProductionTransactions).HasForeignKey(e => e.Fk_ProductionOrderId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
