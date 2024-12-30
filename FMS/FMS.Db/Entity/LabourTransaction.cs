using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class LabourTransactionModel
    {
        public Guid Fk_LabourOdrId { get; set; }
        public Guid Fk_ProductId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal Quantity { get; set; }
    }
    public class LabourTransactionUpdateModel : LabourTransactionModel
    {
        public Guid LabourTransactionId { get; set; }
    }

    public class LabourTransaction : LabourTransactionUpdateModel
    {
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public LabourOrder LabourOrder { get; set; }
        public Product Product { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public Branch Branch { get; set; }
    }
    public class LabourTransactionValidator : AbstractValidator<LabourTransactionModel>
    {
        public LabourTransactionValidator()
        {

        }
    }

    internal class LabourTransactionConfig : IEntityTypeConfiguration<LabourTransaction>
    {
        public void Configure(EntityTypeBuilder<LabourTransaction> builder)
        {
            builder.ToTable("LabourTransactions", "public");
            builder.HasKey(e => e.LabourTransactionId);
            builder.Property(e => e.LabourTransactionId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_LabourOdrId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_ProductId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Quantity).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.HasOne(s => s.LabourOrder).WithMany(pe => pe.LabourTransactions).HasForeignKey(e => e.Fk_LabourOdrId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.Product).WithMany(pe => pe.LabourTransactions).HasForeignKey(e => e.Fk_ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.FinancialYear).WithMany(pe => pe.LabourTransactions).HasForeignKey(e => e.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.Branch).WithMany(pe => pe.LabourTransactions).HasForeignKey(e => e.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
