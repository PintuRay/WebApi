using FluentValidation;
using FMS.Db.CustomVaidator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Db.Entity
{
    public class ReceiptOrderModel
    {
        [Required]
        public string VouvherNo { get; set; }
        [Required]
        public DateTime VoucherDate { get; set; }
        [Required]
        public Guid Fk_CashBankLedgerId { get; set; }
        public string ChequeNo { get; set; } = null;
        public DateTime? ChequeDate { get; set; }
        [Required]
        public string Narration { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public string DrCr { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        public List<ReceiptTransactionModel> ReceiptTransactions { get; set; }
    }
    public class ReceiptOrderValidator : AbstractValidator<ReceiptOrderModel>
    {
        public ReceiptOrderValidator(CustomValidation vaidator)
        {

        }
    }
    public class ReceiptOrderUpdateModel
    {
        [Required]
        public Guid ReceiptOrderId { get; set; }
        [Required]
        public string VouvherNo { get; set; }
        [Required]
        public DateTime VoucherDate { get; set; }
        [Required]
        public Guid Fk_CashBankLedgerId { get; set; }
        public string ChequeNo { get; set; } = null;
        public DateTime? ChequeDate { get; set; }
        [Required]
        public string Narration { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public string DrCr { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        public List<ReceiptTransactionUpdateModel> ReceiptTransactions { get; set; }
    }
    public class ReceiptOrderUpdateValidator : AbstractValidator<ReceiptOrderUpdateModel>
    {
        public ReceiptOrderUpdateValidator(CustomValidation vaidator)
        {

        }
    }
    public class ReceiptOrderDto
    {
        public Guid ReceiptOrderId { get; set; }
        public string VouvherNo { get; set; }
        public DateTime VoucherDate { get; set; }
        public Guid Fk_CashBankLedgerId { get; set; }
        public string ChequeNo { get; set; } = null;
        public DateTime? ChequeDate { get; set; }
        public string Narration { get; set; }
        public decimal TotalAmount { get; set; }
        public string DrCr { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public List<ReceiptTransactionDto> ReceiptTransactions { get; set; }
    }
    public class ReceiptOrder
    {
        public Guid ReceiptOrderId { get; set; }
        public string VouvherNo { get; set; }
        public DateTime VoucherDate { get; set; }
        public Guid Fk_CashBankLedgerId { get; set; }
        public string ChequeNo { get; set; } = null;
        public DateTime? ChequeDate { get; set; }
        public string Narration { get; set; }
        public decimal TotalAmount { get; set; }
        public string DrCr { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public LedgerDev LedgerDev { get; set; }
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public ICollection<ReceiptTransaction> ReceiptTransactions { get; set; }
    }
    internal class ReceiptOrderConfig : IEntityTypeConfiguration<ReceiptOrder>
    {
        public void Configure(EntityTypeBuilder<ReceiptOrder> builder)
        {
            builder.ToTable("ReceiptOrders", "public");
            builder.HasKey(e => e.ReceiptOrderId);
            builder.Property(e => e.ReceiptOrderId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.VouvherNo).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.VoucherDate).HasColumnType("timestamptz").IsRequired(true);
            builder.Property(e => e.ChequeNo).HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.ChequeDate).HasColumnType("timestamptz").IsRequired(false);
            builder.Property(e => e.Fk_CashBankLedgerId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Narration).HasMaxLength(500).IsRequired(false);
            builder.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.DrCr).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(e => e.LedgerDev).WithMany(s => s.ReceiptOrders).HasForeignKey(e => e.Fk_CashBankLedgerId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Branch).WithMany(s => s.ReceiptOrders).HasForeignKey(e => e.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.FinancialYear).WithMany(s => s.ReceiptOrders).HasForeignKey(e => e.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
