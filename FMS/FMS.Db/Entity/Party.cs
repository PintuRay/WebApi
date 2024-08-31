using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class PartyModel
    {
        public Guid Fk_PartyType { get; set; }
        public Guid Fk_SubledgerId { get; set; }
        public Guid Fk_StateId { get; set; }
        public Guid Fk_CityId { get; set; }
        public string PartyName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string GstNo { get; set; }
    }
    public class Party : PartyModel
    {
        public Guid PartyId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public State State { get; set; }
        public City City { get; set; }
        public LedgerDev LedgerDev { get; set; }
        public SubLedger SubLedger { get; set; }
    }
    public class PartyConfig : IEntityTypeConfiguration<Party>
    {
        public void Configure(EntityTypeBuilder<Party> builder)
        {
            builder.ToTable("Parties", "dbo");
            builder.HasKey(e => e.PartyId);
            builder.Property(e => e.PartyId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_PartyType).IsRequired(true);
            builder.Property(e => e.Fk_SubledgerId).IsRequired(true);
            builder.Property(e => e.Fk_StateId).IsRequired(true);
            builder.Property(e => e.Fk_CityId).IsRequired(true);
            builder.Property(e => e.PartyName).HasMaxLength(200).IsRequired(true);
            builder.Property(e => e.Address).HasMaxLength(500).IsRequired(true);
            builder.Property(e => e.Phone).HasMaxLength(20).IsRequired(true);
            builder.Property(e => e.Email).HasMaxLength(200).IsRequired(true);
            builder.Property(e => e.GstNo).HasMaxLength(200).IsRequired(false);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasOne(p => p.LedgerDev).WithMany(s => s.Parties).HasForeignKey(p => p.Fk_PartyType).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.SubLedger).WithMany(s => s.Parties).HasForeignKey(p => p.Fk_SubledgerId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.State).WithMany(s => s.Parties).HasForeignKey(p => p.Fk_StateId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.City).WithMany(s => s.Parties).HasForeignKey(p => p.Fk_CityId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
