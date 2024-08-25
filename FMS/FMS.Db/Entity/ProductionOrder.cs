using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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
    }
    internal class ProductionOrderConfig : IEntityTypeConfiguration<ProductionOrder>
    {
        public void Configure(EntityTypeBuilder<ProductionOrder> builder)
        {
            builder.ToTable("ProductionOrders", "dbo");
            builder.HasKey(e => e.ProductionOrderId);
            builder.Property(e => e.ProductionOrderId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_FinishedGoodId).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
        }
    }
}
