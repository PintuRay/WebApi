using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class UnitModel
    {
        public string UnitName { get; set; }
    }
    public class Unit : UnitModel
    {
        public Guid UnitId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public ICollection<Product> Products { get; set; }
        public ICollection<AlternateUnit> AlternateUnits { get; set; }
    }
    internal class UnitConfig : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Units", "dbo");
            builder.HasKey(e => e.UnitId);
            builder.Property(e => e.UnitId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.UnitName).HasMaxLength(500).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
        }
    }
}
