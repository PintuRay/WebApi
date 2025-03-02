using FluentValidation;
using FMS.Db.CustomVaidator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class SubLedgerBalanceModel
    {
        [Required]
        public Guid Fk_LedgerBalanceId { get; set; }
        [Required]
        public Guid Fk_SubLedgerId { get; set; }
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
    public class SubLedgerBalanceValidator : AbstractValidator<SubLedgerBalanceModel>
    {
        public SubLedgerBalanceValidator(CustomValidation vaidator)
        {

        }
    }
    public class SubLedgerBalanceUpdateModel
    {
        [Required]
        public Guid SubLedgerBalanceId { get; set; }
        [Required]
        public Guid Fk_LedgerBalanceId { get; set; }
        [Required]
        public Guid Fk_SubLedgerId { get; set; }
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
    public class SubLedgerBalanceUpdateValidator : AbstractValidator<SubLedgerBalanceUpdateModel>
    {
        public SubLedgerBalanceUpdateValidator(CustomValidation vaidator)
        {

        }
    }
    public class SubLedgerBalanceDto
    {
        public Guid SubLedgerBalanceId { get; set; }
        public Guid Fk_LedgerBalanceId { get; set; }
        public Guid Fk_SubLedgerId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal OpeningBalance { get; set; }
        public string OpeningBalanceType { get; set; }
        public decimal RunningBalance { get; set; }
        public string RunningBalanceType { get; set; }
    }
    public class SubLedgerBalance
    {
        public Guid SubLedgerBalanceId { get; set; }
        public Guid Fk_LedgerBalanceId { get; set; }
        public Guid Fk_SubLedgerId { get; set; }
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
        public SubLedger SubLedger { get; set; }
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public LedgerBalance LedgerBalance { get; set; }
    }
    internal class SubLedgerBalanceConfig : IEntityTypeConfiguration<SubLedgerBalance>
    {
        public void Configure(EntityTypeBuilder<SubLedgerBalance> builder)
        {
            builder.ToTable("SubLedgerBalances", "public");
            builder.HasKey(e => e.SubLedgerBalanceId);
            builder.Property(e => e.SubLedgerBalanceId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_LedgerBalanceId).IsRequired(true);
            builder.Property(e => e.Fk_SubLedgerId).IsRequired(true);
            builder.Property(e => e.Fk_BranchId).IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).IsRequired(true);
            builder.Property(e => e.OpeningBalance).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.OpeningBalanceType).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.RunningBalance).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.RunningBalanceType).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(bs => bs.SubLedger).WithMany(b => b.SubLedgerBalances).HasForeignKey(bs => bs.Fk_SubLedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bs => bs.Branch).WithMany(b => b.SubLedgerBalances).HasForeignKey(bs => bs.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bs => bs.FinancialYear).WithMany(b => b.SubLedgerBalances).HasForeignKey(bs => bs.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bs => bs.LedgerBalance).WithMany(b => b.SubLedgerBalances).HasForeignKey(bs => bs.Fk_LedgerBalanceId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
