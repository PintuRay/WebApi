using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Db.Entity
{
    public class AddressModel
    {
        [Required]
        public Guid Fk_CountryId { get; set; }
        public string Fk_UserId { get; set; } = null;
        public Guid? Fk_BranchId { get; set; } = null;
        public Guid? Fk_LabourId { get; set; } = null;
        public Guid? Fk_PartyId { get; set; } = null;
        [Required]
        public Guid Fk_StateId { get; set; }
        [Required]
        public Guid Fk_DistId { get; set; }
        [Required]
        public string At { get; set; }
        [Required]
        public string Post { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PinCode { get; set; }
    }
    public class AddressUpdateModel : AddressModel
    {
        [Required]
        public Guid AddressId { get; set; }
    }
    public class AddressValidator : AbstractValidator<AddressModel>
    {
        public AddressValidator()
        {

        }
    }
    public class AddressDto: AddressUpdateModel
    {
        [NotMapped]
        public string CountryName { get; set; }
        [NotMapped]
        public string StateName { get; set; }
        [NotMapped]
        public string DistName { get; set; }
        public AppUser User { get; set; } = null;
        public Labour Labour { get; set; } = null;
        public Party Party { get; set; } = null;
        public Branch Branch { get; set; } = null;
        public Country Country { get; set; } = null;
        public State State { get; set; } = null;
        public Dist Dist { get; set; } = null;
    }
    public class Address : AddressDto
    {
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
    }
    internal class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address", "public");
            builder.HasKey(e => e.AddressId);
            builder.Property(e => e.AddressId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_UserId).HasColumnType("text").IsRequired(false);
            builder.Property(e => e.Fk_LabourId).HasColumnType("uuid").IsRequired(false);
            builder.Property(e => e.Fk_PartyId).HasColumnType("uuid").IsRequired(false);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(false);
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
            //One-To-One Relationship
            builder.HasOne(d => d.User).WithOne(p => p.Address).HasForeignKey<Address>(d => d.Fk_UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Labour).WithOne(p => p.Address).HasForeignKey<Address>(d => d.Fk_LabourId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Party).WithOne(p => p.Address).HasForeignKey<Address>(d => d.Fk_PartyId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Branch).WithOne(p => p.Address).HasForeignKey<Address>(d => d.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            //One-To-Many Relationship
            builder.HasOne(d => d.Country).WithMany(p=>p.Addresses).HasForeignKey(d => d.Fk_CountryId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.State).WithMany(p => p.Addresses).HasForeignKey(d => d.Fk_StateId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Dist).WithMany(p => p.Addresses).HasForeignKey(d => d.Fk_DistId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
              new Address
              {
                  AddressId = Guid.Parse("c9b62c55-1b06-485d-a71b-d92fee4f4428"),
                  Fk_UserId = "4431f16a-6bc7-4e9b-bada-c491fcc81a58",
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
}