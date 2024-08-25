using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FMS.Db.Entity
{
    public class ProductionModel
    {
        public Guid Fk_FinishedGoodId { get; set; }
        public Guid Fk_RawMaterialId { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
    public class Production : ProductionModel
    {
        public Guid ProductionId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
    }
    internal class ProductionConfig : IEntityTypeConfiguration<Production>
    {
        public void Configure(EntityTypeBuilder<Production> builder)
        {
            builder.ToTable("Productions", "dbo");
            builder.HasKey(e => e.ProductionId);
            builder.Property(e => e.ProductionId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_RawMaterialId).IsRequired(true);
            builder.Property(e => e.Fk_FinishedGoodId).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.Property(e => e.Quantity).HasColumnType("decimal(18, 5)").IsRequired(true);
            builder.Property(e => e.Unit).HasMaxLength(100).IsRequired(true);
        }
    }
}
