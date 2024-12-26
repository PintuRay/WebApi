﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class LedgerSubGroupDevModel
    {
        public Guid Fk_LedgerGroupId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public string SubGroupName { get; set; }
    }
    public class LedgerSubGroupDev : LedgerSubGroupDevModel
    {
        public Guid LedgerSubGroupId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public LedgerGroup LedgerGroup { get; set; }
        public Branch Branch { get; set; }
        public ICollection<LedgerDev> LedgersDev { get; set; }
    }
    internal class LedgerSubGroupDevConfig : IEntityTypeConfiguration<LedgerSubGroupDev>
    {
        public void Configure(EntityTypeBuilder<LedgerSubGroupDev> builder)
        {
            builder.ToTable("LedgerSubGroupDevs", "public");
            builder.HasKey(e => e.LedgerSubGroupId);
            builder.Property(e => e.LedgerSubGroupId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_LedgerGroupId).IsRequired(true);
            builder.Property(e => e.Fk_BranchId).IsRequired(true);
            builder.Property(e => e.SubGroupName).IsRequired(true).HasMaxLength(200);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
                       builder.Property(e => e.CreatedDate).HasColumnType("timestamp").HasDefaultValueSql("CURRENT_TIMESTAMP"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamp").HasDefaultValueSql("CURRENT_TIMESTAMP"); 
            builder.HasOne(sg => sg.LedgerGroup).WithMany(g => g.LedgerSubGroupsDev).HasForeignKey(sg => sg.Fk_LedgerGroupId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(sg => sg.Branch).WithMany(g => g.LedgerSubGroupDev).HasForeignKey(sg => sg.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
