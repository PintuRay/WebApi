using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Db.Entity
{
    public class ProductionOrderModel
    {
        public Guid Fk_FinishedGoodId { get; set; }
        public ICollection<ProductionTransaction> ProductionTransactions { get; set; }
    }
    public class ProductionOrder : ProductionOrderModel
    {
        public Guid ProductionOrderId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        [NotMapped]
        public string FinishedGoodName { get; set; }
        public Product Product { get; set; }
    }
    internal class ProductionOrderConfig : IEntityTypeConfiguration<ProductionOrder>
    {
        public void Configure(EntityTypeBuilder<ProductionOrder> builder)
        {
            builder.ToTable("ProductionOrders", "public");
            builder.HasKey(e => e.ProductionOrderId);
            builder.Property(e => e.ProductionOrderId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_FinishedGoodId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(e => e.Product).WithMany(s => s.ProductionOrders).HasForeignKey(e => e.Fk_FinishedGoodId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
