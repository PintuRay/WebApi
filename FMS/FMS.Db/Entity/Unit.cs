using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class UnitModel
    {
        [Required]
        public string UnitName { get; set; }
    }
    public class UnitUpdateModel : UnitModel
    {
        [Required]
        public Guid UnitId { get; set; }
    }
    public class UnitValidator : AbstractValidator<UnitModel>
    {
        public UnitValidator()
        {

        }
    }
    public class UnitDto : UnitUpdateModel
    {
        public ICollection<Product> Products { get; set; }
        public ICollection<AlternateUnit> AlternateUnits { get; set; }
    }
    public class Unit : UnitDto
    {
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;

    }
    internal class UnitConfig : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Units", "public");
            builder.HasKey(e => e.UnitId);
            builder.Property(e => e.UnitId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.UnitName).HasMaxLength(500).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
        }
    }
}
