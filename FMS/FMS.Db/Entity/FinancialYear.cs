using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
namespace FMS.Db.Entity
{
  
    public class FinancialYearModel
    {
        [Required]
        public string Financial_Year { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
    public class FinancialYearUpdateModel : FinancialYearModel
    {
        [Required]
        public Guid FinancialYearId { get; set; }
    }
    public class FinancialYearValidator : AbstractValidator<FinancialYearModel>
    {
        public FinancialYearValidator()
        {

        }
    }
    public class FinancialYearDto: FinancialYearUpdateModel
    {
        public ICollection<BranchFinancialYear> BranchFinancialYears { get; set; }
        public ICollection<Stock> Stocks { get; set; }
        public ICollection<LabourRate> LabourRates { get; set; }
        public ICollection<LedgerBalance> LedgerBalances { get; set; }
        public ICollection<SubLedgerBalance> SubLedgerBalances { get; set; }
        public ICollection<InwardSupplyOrder> InwardSupplyOrders { get; set; }
        public ICollection<InwardSupplyTransaction> InwardSupplyTransactions { get; set; }
        public ICollection<OutwardSupplyOrder> OutwardSupplyOrders { get; set; }
        public ICollection<OutwardSupplyTransaction> OutwardSupplyTransactions { get; set; }
        public ICollection<ProductionOrder> ProductionOrders { get; set; }
        public ICollection<ProductionTransaction> ProductionTransactions { get; set; }
        public ICollection<DamageOrder> DamageOrders { get; set; }
        public ICollection<DamageTransaction> DamageTransactions { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public ICollection<PurchaseTransaction> PurchaseTransactions { get; set; }
        public ICollection<PurchaseReturnOrder> PurchaseReturnOrders { get; set; }
        public ICollection<PurchaseReturnTransaction> PurchaseReturnTransactions { get; set; }
        public ICollection<SalesOrder> SalesOrders { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }
        public ICollection<SalesReturnOrder> SalesReturnOrders { get; set; }
        public ICollection<SalesReturnTransaction> SalesReturnTransactions { get; set; }
        public ICollection<JournalOrder> JournalOrders { get; set; }
        public ICollection<JournalTransaction> JournalTransactions { get; set; }
        public ICollection<PaymentOrder> PaymentOrders { get; set; }
        public ICollection<PaymentTransaction> PaymentTransactions { get; set; }
        public ICollection<ReceiptOrder> ReceiptOrders { get; set; }
        public ICollection<ReceiptTransaction> ReceiptTransactions { get; set; }
    }
    public class FinancialYear : FinancialYearDto
    {
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
    }
    internal class FinancialYearConfig : IEntityTypeConfiguration<FinancialYear>
    {
        public void Configure(EntityTypeBuilder<FinancialYear> builder)
        {
            builder.ToTable("FinancialYears", "public");
            builder.HasKey(e => e.FinancialYearId);
            builder.Property(e => e.FinancialYearId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Financial_Year).IsRequired(true);
            builder.Property(e => e.StartDate).IsRequired(true).HasColumnType("timestamptz");
            builder.Property(e => e.EndDate).IsRequired(true).HasColumnType("timestamptz");
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
        }
    }
}
