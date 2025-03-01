using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class LabourTypeModel
    {
        [Required]
        public string Labour_Type { get; set; }
    }
    public class LabourTypeUpdateMdel 
    {
        [Required]
        public Guid LabourTypeId { get; set; }
        [Required]
        public string Labour_Type { get; set; }
    }
    public class LabourTypeDto
    {
        public Guid LabourTypeId { get; set; }
        public string Labour_Type { get; set; }
    }
    public class LabourType
    {
        public Guid LabourTypeId { get; set; }
        public string Labour_Type { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public ICollection<Labour> Labours { get; set; }
    }
    public class LabourTypeConfig : IEntityTypeConfiguration<LabourType>
    {
        public void Configure(EntityTypeBuilder<LabourType> builder)
        {
            builder.ToTable("LabourTypes", "public");
            builder.HasKey(e => e.LabourTypeId);
            builder.Property(e => e.LabourTypeId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Labour_Type).HasMaxLength(100).IsRequired();
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasData(
                new LabourType() { LabourTypeId = Guid.Parse("6C2758A2-79B5-43A6-8851-C6F975433B0F"), Labour_Type = "SERVICE" },
                new LabourType() { LabourTypeId = Guid.Parse("5E514855-55A0-459C-8B8B-DEF7696D9AD0"), Labour_Type = "PRODUCTION" }
               );
        }
    }
}
