using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class LabourTransactionModel
    {
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid Fk_LabourOdrId { get; set; }
        public Guid Fk_ProductId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal Quantity { get; set; }
    }
    public class LabourTransaction : LabourTransactionModel
    {
        public Guid LabourTransactionId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public LabourOrder LabourOrder { get; set; }
        public Product Product { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public Branch Branch { get; set; }
    }
    internal class LabourTransactionConfig : IEntityTypeConfiguration<LabourTransaction>
    {
        public void Configure(EntityTypeBuilder<LabourTransaction> builder)
        {
            builder.ToTable("LabourTransactions", "dbo");
            builder.HasKey(e => e.LabourTransactionId);
            builder.Property(e => e.LabourTransactionId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_LabourOdrId).IsRequired(true);
            builder.Property(e => e.Fk_ProductId).IsRequired(true);
            builder.Property(e => e.Fk_BranchId).IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).IsRequired(true);
            builder.Property(e => e.TransactionNo).IsRequired(true);
            builder.Property(e => e.TransactionDate).HasColumnType("datetime").IsRequired(true);
            builder.Property(e => e.Quantity).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasOne(s => s.LabourOrder).WithMany(pe => pe.LabourTransactions).HasForeignKey(e => e.Fk_LabourOdrId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Product).WithMany(pe => pe.LabourTransactions).HasForeignKey(e => e.Fk_ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.FinancialYear).WithMany(pe => pe.LabourTransactions).HasForeignKey(e => e.Fk_FinancialYearId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Branch).WithMany(pe => pe.LabourTransactions).HasForeignKey(e => e.Fk_BranchId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
