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
    public class UnitValidator : AbstractValidator<UnitModel>
    {
        public UnitValidator()
        {

        }
    }
    public class UnitUpdateModel
    {
        [Required]
        public Guid UnitId { get; set; }
        [Required]
        public string UnitName { get; set; }
    }
    public class UnitUpdateValidator : AbstractValidator<UnitUpdateModel>
    {
        public UnitUpdateValidator()
        {

        }
    }
    public class UnitDto
    {
        public Guid UnitId { get; set; }
        public string UnitName { get; set; }
    }
    public class Unit
    {
        public Guid UnitId { get; set; }
        public string UnitName { get; set; }
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
