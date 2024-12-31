using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class AddressModel
    {
        public string Fk_UserId { get; set; }
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
        public Country Country { get; set; }
        public State State { get; set; }
        public Dist Dist { get; set; }
        public AppUser User { get; set; }
        public Labour Labour { get; set; }
        public Party Party { get; set; }
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
            builder.Property(e => e.Fk_UserId).IsRequired(true);
            builder.Property(e => e.Fk_CountryId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_StateId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_DistId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValue(DateTime.UtcNow); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValue(DateTime.UtcNow);
            //One-To-One Relationship
            builder.HasOne(d => d.User).WithOne(p => p.Address).HasForeignKey<Address>(d => d.Fk_UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Labour).WithOne(p => p.Address).HasForeignKey<Address>(d => d.Fk_UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Party).WithOne(p => p.Address).HasForeignKey<Address>(d => d.Fk_UserId).OnDelete(DeleteBehavior.Cascade);
            //One-To-Many Relationship
            builder.HasOne(d => d.Country).WithMany(p => p.Addresses).HasForeignKey(d => d.Fk_CountryId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.State).WithMany(p => p.Addresses).HasForeignKey(d => d.Fk_StateId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Dist).WithMany(p => p.Addresses).HasForeignKey(d => d.Fk_DistId).OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class AddressValidator : AbstractValidator<AddressModel>
    {
        public AddressValidator()
        {

        }
    }
}