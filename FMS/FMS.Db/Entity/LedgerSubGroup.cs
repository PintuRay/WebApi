using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class LedgerSubGroupModel
    {
        public Guid Fk_LedgerGroupId { get; set; }
        public Guid? Fk_BranchId { get; set; }
        public string SubGroupName { get; set; }
    }
    public class LedgerSubGroupUpdateModel : LedgerSubGroupModel
    {
        public Guid LedgerSubGroupId { get; set; }
    }
    public class LedgerSubGroup : LedgerSubGroupUpdateModel
    {
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public LedgerGroup LedgerGroup { get; set; }
        public Branch Branch { get; set; }
        public ICollection<Ledger> Ledgers { get; set; }
    }
    public class LedgerSubGroupValidator : AbstractValidator<LedgerSubGroupModel>
    {
        public LedgerSubGroupValidator()
        {

        }
    }
    internal class LedgerSubGroupConfig : IEntityTypeConfiguration<LedgerSubGroup>
    {
        public void Configure(EntityTypeBuilder<LedgerSubGroup> builder)
        {
            builder.ToTable("LedgerSubGroups", "public");
            builder.HasKey(e => e.LedgerSubGroupId);
            builder.Property(e => e.LedgerSubGroupId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_LedgerGroupId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(false);
            builder.Property(e => e.SubGroupName).IsRequired(true).HasMaxLength(200);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.HasOne(sg => sg.LedgerGroup).WithMany(g => g.LedgerSubGroups).HasForeignKey(sg => sg.Fk_LedgerGroupId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(sg => sg.Branch).WithMany(g => g.LedgerSubGroup).HasForeignKey(sg => sg.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
