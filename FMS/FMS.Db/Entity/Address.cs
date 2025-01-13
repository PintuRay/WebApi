using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class AddressModel
    {
        public Guid Fk_CountryId { get; set; }
        public Guid Fk_StateId { get; set; }
        public Guid Fk_DistId { get; set; }
        public string At { get; set; }
        public string Post { get; set; }
        public string City { get; set; }
        public string PinCode { get; set; }
    }
    public class AddressUpdateModel : AddressModel
    {
        public Guid AddressId { get; set; }
    }
    public class Address : AddressUpdateModel
    {
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public ICollection<AppUser> Users { get; set; }
        public ICollection<Labour> Labours { get; set; }
        public ICollection<Party> Parties { get; set; }
    }
    internal class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address", "public");
            builder.HasKey(e => e.AddressId);
            builder.Property(e => e.AddressId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.At).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.Post).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.City).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.PinCode).HasMaxLength(6).IsRequired(true);
            builder.Property(e => e.Fk_CountryId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_StateId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_DistId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValue(DateTime.UtcNow);
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValue(DateTime.UtcNow);
            builder.HasData(
              new Address
              {
                  AddressId = Guid.Parse("c9b62c55-1b06-485d-a71b-d92fee4f4428"),
                  Fk_CountryId = Guid.Parse("e02eb064-def5-434a-8798-6f144a54003c"),
                  Fk_StateId = Guid.Parse("2d1ea7cb-cf85-4be6-bdda-422e99bea59e"),
                  Fk_DistId = Guid.Parse("40d9d1a4-ad94-4f14-a23f-d4ec3317d8f9"),
                  At ="DHANAMANDAL",
                  Post="BRAHMANSAILO",
                  City ="CUTTACK",
                  PinCode="754018"
              }
            );
        }
    }
    public class AddressValidator : AbstractValidator<AddressModel>
    {
        public AddressValidator()
        {

        }
    }
}