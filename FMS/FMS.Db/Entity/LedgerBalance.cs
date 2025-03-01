using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class LedgerBalanceModel
    {
        [Required]
        public Guid Fk_LedgerId { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public decimal OpeningBalance { get; set; }
        [Required]
        public string OpeningBalanceType { get; set; }
        [Required]
        public decimal RunningBalance { get; set; }
        [Required]
        public string RunningBalanceType { get; set; }
    }
    public class LedgerBalanceValidator : AbstractValidator<LedgerBalanceModel>
    {
        public LedgerBalanceValidator()
        {

        }
    }
    public class LedgerBalanceUpdateModel
    {
        [Required]
        public Guid LedgerBalanceId { get; set; }
        [Required]
        public Guid Fk_LedgerId { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public decimal OpeningBalance { get; set; }
        [Required]
        public string OpeningBalanceType { get; set; }
        [Required]
        public decimal RunningBalance { get; set; }
        [Required]
        public string RunningBalanceType { get; set; }
    }
    public class LedgerBalanceUpdateValidator : AbstractValidator<LedgerBalanceUpdateModel>
    {
        public LedgerBalanceUpdateValidator()
        {

        }
    }
    public class LedgerBalanceDto
    {
        public Guid LedgerBalanceId { get; set; }
        public Guid Fk_LedgerId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal OpeningBalance { get; set; }
        public string OpeningBalanceType { get; set; }
        public decimal RunningBalance { get; set; }
        public string RunningBalanceType { get; set; }
    }
    public class LedgerBalance
    {
        public Guid LedgerBalanceId { get; set; }
        public Guid Fk_LedgerId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal OpeningBalance { get; set; }
        public string OpeningBalanceType { get; set; }
        public decimal RunningBalance { get; set; }
        public string RunningBalanceType { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Ledger Ledger { get; set; }
        public LedgerDev LedgerDev { get; set; }
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public ICollection<SubLedgerBalance> SubLedgerBalances { get; set; }
    }
    internal class LedgerBalanceConfig : IEntityTypeConfiguration<LedgerBalance>
    {
        public void Configure(EntityTypeBuilder<LedgerBalance> builder)
        {
            builder.ToTable("LedgerBalances", "public");
            builder.HasKey(e => e.LedgerBalanceId);
            builder.Property(e => e.LedgerBalanceId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_LedgerId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.OpeningBalance).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.OpeningBalanceType).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.RunningBalance).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.RunningBalanceType).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(bs => bs.Ledger).WithMany(b => b.LedgerBalances).HasForeignKey(bs => bs.Fk_LedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bs => bs.LedgerDev).WithMany(b => b.LedgerBalances).HasForeignKey(bs => bs.Fk_LedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bs => bs.Branch).WithMany(b => b.LedgerBalances).HasForeignKey(bs => bs.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bs => bs.FinancialYear).WithMany(b => b.LedgerBalances).HasForeignKey(bs => bs.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
