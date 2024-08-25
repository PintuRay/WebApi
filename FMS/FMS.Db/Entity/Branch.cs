using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace FMS.Db.Entity
{
    public class BranchModel
    {
        [Required, MinLength(3, ErrorMessage = "BranchName should be at least 3 characters long."), RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "BranchName should only contain letters and spaces.")]
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        [Required, RegularExpression(@"^\d{10}$", ErrorMessage = "ContactNumber should have exactly 10 digits."), StringLength(10, ErrorMessage = "ContactNumber should have exactly 10 digits.", MinimumLength = 10)]
        public string ContactNumber { get; set; }
        [Required, RegularExpression(@"^[A-Z][A-Za-z0-9]*$", ErrorMessage = "BranchCode should start with a letter and followed by a combination of letters and numbers.")]
        public string BranchCode { get; set; }
    }
    public class Branch : BranchModel
    {
        public Guid BranchId { get; set; }
        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        //Collection Navigation Property
        public ICollection<BranchFinancialYear> BranchFinancialYears { get; set; }
        public ICollection<UserBranch> UserBranch { get; set; }
        public ICollection<Labour> Labours { get; set; }
        public ICollection<Stock> Stocks { get; set; }
        public ICollection<LedgerSubGroup> LedgerSubGroup { get; set; }
        public ICollection<LedgerSubGroupDev> LedgerSubGroupDev { get; set; }
        public ICollection<LedgerBalance> LedgerBalances { get; set; }
        public ICollection<SubLedger> SubLedgers { get; set; }
        public ICollection<SubLedgerBalance> SubLedgerBalances { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public ICollection<SalesOrder> SalesOrders { get; set; }
        public ICollection<PurchaseTransaction> PurchaseTransactions { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }
        public ICollection<LabourOrder> LabourOrders { get; set; }
        public ICollection<LabourTransaction> LabourTransactions { get; set; }
        public ICollection<JournalOrder> JournalOrders { get; set; }
        public ICollection<JournalTransaction> JournalTransactions { get; set; }
        public ICollection<PaymentOrder> PaymentOrders { get; set; }
        public ICollection<PaymentTransaction> PaymentTransactions { get; set; }
        public ICollection<ReceiptOrder> ReceiptOrders { get; set; }
        public ICollection<ReceiptTransaction> ReceiptTransactions { get; set; }
        public ICollection<SalesReturnOrder> SalesReturnOrders { get; set; }
        public ICollection<PurchaseReturnOrder> PurchaseReturnOrders { get; set; }
        public ICollection<SalesReturnTransaction> SalesReturnTransactions { get; set; }
        public ICollection<PurchaseReturnTransaction> PurchaseReturnTransactions { get; set; }
        public ICollection<InwardSupplyOrder> InwardSupplyOrders { get; set; }
        public ICollection<OutwardSupplyOrder> OutwardSupplyOrders { get; set; }
        public ICollection<InwardSupplyTransaction> InwardSupplyTransactions { get; set; }
        public ICollection<OutwardSupplyTransaction> OutwardSupplyTransactions { get; set; }
        public ICollection<DamageOrder> DamageOrders { get; set; }
        public ICollection<DamageTransaction> DamageTransactions { get; set; }
        public ICollection<Company> Companies { get; set; }
        public ICollection<LabourRate> LabourRates { get; set; }
    }
    internal class BranchConfig : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.ToTable("Branches", "dbo");
            builder.HasKey(e => e.BranchId);
            builder.Property(e => e.BranchId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.BranchName).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.BranchAddress).HasMaxLength(500).IsRequired(true);
            builder.Property(e => e.BranchCode).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.ContactNumber).HasMaxLength(50).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
        }
    }
}
