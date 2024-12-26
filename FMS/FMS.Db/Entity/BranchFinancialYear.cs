using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json.Serialization;

namespace FMS.Db.Entity
{
    public class BranchFinancialYearModel
    {
        public Guid Fk_FinancialYearId { get; set; }
        public Guid Fk_BranchId { get; set; }
    }
    public class BranchFinancialYear: BranchFinancialYearModel
    {
        public Guid BranchFinancialYearId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        //Reference Navigation Property
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
    }
    internal class BranchFinancialYearConfig : IEntityTypeConfiguration<BranchFinancialYear>
    {
        public void Configure(EntityTypeBuilder<BranchFinancialYear> builder)
        {
            builder.ToTable("BranchFinancialYears", "public");
            builder.HasKey(e => e.BranchFinancialYearId);
            builder.Property(e => e.BranchFinancialYearId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamp").HasDefaultValueSql("CURRENT_TIMESTAMP"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamp").HasDefaultValueSql("CURRENT_TIMESTAMP"); 
            //One-To-Many Relation
            builder.HasOne(fy => fy.FinancialYear).WithMany(b => b.BranchFinancialYears).HasForeignKey(fy => fy.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(br => br.Branch).WithMany(b => b.BranchFinancialYears).HasForeignKey(fy => fy.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
