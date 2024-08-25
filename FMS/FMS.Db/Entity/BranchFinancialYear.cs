using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

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
            builder.ToTable("BranchFinancialYears", "dbo");
            builder.HasKey(e => e.BranchFinancialYearId);
            builder.Property(e => e.BranchFinancialYearId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_BranchId).IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            //One-To-Many Relation
            builder.HasOne(fy => fy.FinancialYear).WithMany(b => b.BranchFinancialYears).HasForeignKey(fy => fy.Fk_FinancialYearId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(br => br.Branch).WithMany(b => b.BranchFinancialYears).HasForeignKey(fy => fy.Fk_BranchId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
