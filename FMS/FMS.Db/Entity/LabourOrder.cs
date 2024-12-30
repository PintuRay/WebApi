using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class LabourOrderModel
    {
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid Fk_ProductId { get; set; }
        public string Fk_LabourId { get; set; }
        public Guid Fk_LabourTypeId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public Guid FK_BranchId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal OTAmount { get; set; }
        public string Narration { get; set; }
        public ICollection<LabourTransaction> LabourTransactions { get; set; }
    }
    public class LabourOrderUpdateModel : LabourOrderModel
    {
        public Guid LabourOrderId { get; set; }
    }

    public class LabourOrder: LabourOrderUpdateModel
    {
        public bool  IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Product Product { get; set; }
        public Labour Labour { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public Branch Branch { get; set; }
        public LabourType LabourType { get; set; }

    }
    public class LabourOrderValidator : AbstractValidator<LabourOrderModel>
    {
        public LabourOrderValidator()
        {

        }
    }

    internal class LabourOrderConfig : IEntityTypeConfiguration<LabourOrder>
    {
        public void Configure(EntityTypeBuilder<LabourOrder> builder)
        {
            builder.ToTable("LabourOrders", "public");
            builder.HasKey(e => e.LabourOrderId);
            builder.Property(e => e.LabourOrderId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.TransactionNo).IsRequired(true);
            builder.Property(e => e.Fk_ProductId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_LabourId).IsRequired(true);
            builder.Property(e => e.Fk_LabourTypeId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.FK_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.TransactionDate).HasColumnType("timestamptz").IsRequired(true);
            builder.Property(e => e.Quantity).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.Rate).HasColumnType("decimal(18, 4)").HasDefaultValue(0);
            builder.Property(e => e.Amount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.OTAmount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.Narration).IsRequired(false);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.HasOne(p => p.Product).WithMany(pe => pe.LabourOrders).HasForeignKey(e => e.Fk_ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(l => l.Labour).WithMany(pe => pe.LabourOrders).HasForeignKey(e => e.Fk_LabourId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(f => f.FinancialYear).WithMany(pe => pe.LabourOrders).HasForeignKey(e => e.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Branch).WithMany(pe => pe.LabourOrders).HasForeignKey(e => e.FK_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.LabourType).WithMany(pe => pe.LabourOrders).HasForeignKey(e => e.Fk_LabourTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
