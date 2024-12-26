using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class LabourTypeModel
    {
        public string Labour_Type { get; set; }
    }
    public class LabourType: LabourTypeModel
    {
        public Guid LabourTypeId { get; set; }
        public ICollection<Labour> Labours { get; set; }
        public ICollection<LabourOrder> LabourOrders { get; set; }
    }
    public class LabourTypeConfig : IEntityTypeConfiguration<LabourType>
    {
        public void Configure(EntityTypeBuilder<LabourType> builder)
        {
            builder.ToTable("LabourTypes", "public");
            builder.HasKey(e => e.LabourTypeId);
            builder.Property(e => e.LabourTypeId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Labour_Type).HasMaxLength(100).IsRequired();
            builder.HasData(
                new LabourType() { LabourTypeId = Guid.Parse("6C2758A2-79B5-43A6-8851-C6F975433B0F"), Labour_Type = "SERVICE" },
                new LabourType() { LabourTypeId = Guid.Parse("5E514855-55A0-459C-8B8B-DEF7696D9AD0"), Labour_Type = "PRODUCTION" }
               );
        }
    }
}
