using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FMS.Db.Entity
{
    public class StockModel
    {
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_ProductId { get; set; }
        public Guid Fk_FinancialYear { get; set; }
        public int MinQty { get; set; }
        public int MaxQty { get; set; }
        public decimal OpeningStock { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal AvilableStock { get; set; }
    }
    public class Stock : StockModel
    {
        public Guid StockId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Branch Branch { get; set; }
        public Product Product { get; set; }
        public FinancialYear FinancialYear { get; set; }
    }
    internal class StockConfig : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks", "dbo");
            builder.HasKey(e => e.StockId);
            builder.Property(e => e.StockId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_ProductId).IsRequired(true);
            builder.Property(e => e.Fk_BranchId).IsRequired(true);
            builder.Property(e => e.Fk_FinancialYear).IsRequired(true);
            builder.Property(e => e.MinQty).HasColumnType("decimal(18, 5)").HasDefaultValue(0.00);
            builder.Property(e => e.MaxQty).HasColumnType("decimal(18, 5)").HasDefaultValue(0.00);
            builder.Property(e => e.OpeningStock).HasColumnType("decimal(18, 2)").HasDefaultValue(0.00);
            builder.Property(e => e.Rate).HasColumnType("decimal(18, 2)").HasDefaultValue(0.00);
            builder.Property(e => e.Amount).HasColumnType("decimal(18, 2)").HasDefaultValue(0.00);
            builder.Property(e => e.AvilableStock).HasColumnType("decimal(18, 2)").HasDefaultValue(0.00);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasOne(bs => bs.Branch).WithMany(b => b.Stocks).HasForeignKey(bs => bs.Fk_BranchId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(bs => bs.Product).WithMany(b => b.Stocks).HasForeignKey(bs => bs.Fk_ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(bs => bs.FinancialYear).WithMany(b => b.Stocks).HasForeignKey(bs => bs.Fk_FinancialYear).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
