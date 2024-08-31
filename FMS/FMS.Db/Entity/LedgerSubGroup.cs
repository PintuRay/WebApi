using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class LedgerSubGroupModel
    {
        public Guid Fk_LedgerGroupId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public string SubGroupName { get; set; }
    }
    public class LedgerSubGroup : LedgerSubGroupModel
    {
        public Guid LedgerSubGroupId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public LedgerGroup LedgerGroup { get; set; }
        public Branch Branch { get; set; }
        public ICollection<Ledger> Ledgers { get; set; }
    }
    internal class LedgerSubGroupConfig : IEntityTypeConfiguration<LedgerSubGroup>
    {
        public void Configure(EntityTypeBuilder<LedgerSubGroup> builder)
        {
            builder.ToTable("LedgerSubGroups", "dbo");
            builder.HasKey(e => e.LedgerSubGroupId);
            builder.Property(e => e.LedgerSubGroupId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_LedgerGroupId).IsRequired(true);
            builder.Property(e => e.Fk_BranchId).IsRequired(true);
            builder.Property(e => e.SubGroupName).IsRequired(true).HasMaxLength(200);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasOne(sg => sg.LedgerGroup).WithMany(g => g.LedgerSubGroups).HasForeignKey(sg => sg.Fk_LedgerGroupId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(sg => sg.Branch).WithMany(g => g.LedgerSubGroup).HasForeignKey(sg => sg.Fk_BranchId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
