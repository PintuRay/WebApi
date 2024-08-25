using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FMS.Db.Entity
{
    public class SalesConfigModel
    {
        public Guid Fk_FinishedGoodId { get; set; }
        public Guid Fk_SubFinishedGoodId { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
    public class SalesConfig : SalesConfigModel
    {
        public Guid SalesConfigId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
    }
    public class SalesConfigConfig : IEntityTypeConfiguration<SalesConfig>
    {
        public void Configure(EntityTypeBuilder<SalesConfig> builder)
        {
            builder.ToTable("SalesConfigs", "dbo");
            builder.HasKey(e => e.SalesConfigId);
            builder.Property(e => e.SalesConfigId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_FinishedGoodId).IsRequired(true);
            builder.Property(e => e.Fk_SubFinishedGoodId).IsRequired(true);
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
