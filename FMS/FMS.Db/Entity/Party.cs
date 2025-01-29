using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Db.Entity
{
    public class PartyModel
    {
        [Required]
        public Guid Fk_PartyType { get; set; }
        [Required]
        public Guid Fk_SubledgerId { get; set; }
        [Required]
        public string PartyName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string GstNo { get; set; }
        [NotMapped]
        public AddressModel Address { get; set; }
    }
    public class PartyUpdateModel : PartyModel
    {
        [Required]
        public Guid PartyId { get; set; }
        [NotMapped]
        public new AddressUpdateModel Address { get; set; }
    }
    public class PartyValidator : AbstractValidator<PartyModel>
    {
        public PartyValidator()
        {

        }
    }
    public class PartyDto : PartyUpdateModel
    {
        public new Address Address { get; set; }
        public LedgerDev LedgerDev { get; set; }
        public SubLedger SubLedger { get; set; }
    }
    public class Party : PartyDto
    {
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
    }
    public class PartyConfig : IEntityTypeConfiguration<Party>
    {
        public void Configure(EntityTypeBuilder<Party> builder)
        {
            builder.ToTable("Parties", "public");
            builder.HasKey(e => e.PartyId);
            builder.Property(e => e.PartyId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_PartyType).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_SubledgerId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.PartyName).HasMaxLength(200).IsRequired(true);
            builder.Property(e => e.Phone).HasMaxLength(20).IsRequired(true);
            builder.Property(e => e.Email).HasMaxLength(200).IsRequired(true);
            builder.Property(e => e.GstNo).HasMaxLength(200).IsRequired(false);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            //One-To-Many Relationship
            builder.HasOne(p => p.LedgerDev).WithMany(s => s.Parties).HasForeignKey(p => p.Fk_PartyType).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.SubLedger).WithMany(s => s.Parties).HasForeignKey(p => p.Fk_SubledgerId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
