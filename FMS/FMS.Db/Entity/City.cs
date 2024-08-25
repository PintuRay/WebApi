using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FMS.Db.Entity
{
    public class CityModel
    {
        public Guid Fk_StateId { get; set; }
        public string CityName { get; set; }
    }
    public class City: CityModel
    {
        public Guid CityId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public State State { get; set; }
        public ICollection<Party> Parties { get; set; }
    }
    internal class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities", "dbo");
            builder.HasKey(e => e.CityId);
            builder.Property(e => e.CityId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_StateId).IsRequired(true);
            builder.Property(e => e.CityName).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasOne(c => c.State).WithMany(s => s.Cities).HasForeignKey(c => c.Fk_StateId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
