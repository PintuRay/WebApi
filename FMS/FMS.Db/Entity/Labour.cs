using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class LabourModel
    {
        public string LabourName { get; set; }
        public Guid? Fk_Labour_TypeId { get; set; }
        public Guid Fk_SubLedgerId { get; set; }
        public Guid? Fk_BranchId { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Reference { get; set; }
    }
    public class Labour : LabourModel
    {
        public Guid LabourId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public LabourType LabourType { get; set; }
        public Branch Branch { get; set; }
        public SubLedger SubLedger { get; set; }
        public ICollection<LabourOrder> LabourOrders { get; set; }
        public ICollection<DamageOrder> DamageOrders { get; set; }
    }
    internal class LabourConfig : IEntityTypeConfiguration<Labour>
    {
        public void Configure(EntityTypeBuilder<Labour> builder)
        {
            builder.ToTable("Labours", "public");
            builder.HasKey(e => e.LabourId);
            builder.Property(e => e.LabourId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_Labour_TypeId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_SubLedgerId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(false);
            builder.Property(e => e.LabourName).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.Address).HasMaxLength(500).IsRequired(true);
            builder.Property(e => e.Phone).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.Reference).HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamp").HasDefaultValueSql("CURRENT_TIMESTAMP"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamp").HasDefaultValueSql("CURRENT_TIMESTAMP"); 
            builder.HasOne(d => d.SubLedger).WithMany(e => e.Labours).HasForeignKey(d => d.Fk_SubLedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.LabourType).WithMany(e => e.Labours).HasForeignKey(d => d.Fk_Labour_TypeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Branch).WithMany(e => e.Labours).HasForeignKey(d => d.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
