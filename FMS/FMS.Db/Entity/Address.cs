using FluentValidation;
using FMS.Db.CustomVaidator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class AddressModel
    {
        [Required]
        public Guid Fk_CountryId { get; set; }
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
    public class Address : AddressModel
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Country Country { get; set; }
        public State State { get; set; }
        public Dist Dist { get; set; }
    }
    internal class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address", "dbo");
            builder.HasKey(e => e.AddressId);
            builder.Property(e => e.AddressId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.At).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.Post).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.City).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.PinCode).HasMaxLength(6).IsRequired(true);
            builder.Property(e => e.UserId).IsRequired(true);
            builder.Property(e => e.Fk_CountryId).IsRequired(true);
            builder.Property(e => e.Fk_StateId).IsRequired(true);
            builder.Property(e => e.Fk_DistId).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            //One-To-Many Relationship
            builder.HasOne(d => d.Country).WithMany(p => p.Addresses).HasForeignKey(d => d.Fk_CountryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.State).WithMany(p => p.Addresses).HasForeignKey(d => d.Fk_StateId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.Dist).WithMany(p => p.Addresses).HasForeignKey(d => d.Fk_DistId).OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class AddressValidator : AbstractValidator<AddressModel>
    {
        public AddressValidator(CustomValidation vaidator)
        {

        }
    }
}