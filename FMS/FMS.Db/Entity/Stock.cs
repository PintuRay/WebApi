using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class StockModel
    {
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_ProductId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public int MinQty { get; set; }
        [Required]
        public int MaxQty { get; set; }
        [Required]
        public decimal OpeningStock { get; set; }
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public decimal AvilableStock { get; set; }
    }
    public class StockUpdateModel : StockModel
    {
        [Required]
        public Guid StockId { get; set; }
    }
    public class StockValidator : AbstractValidator<StockModel>
    {
        public StockValidator()
        {

        }
    }
    public class StockDto : StockUpdateModel
    {
        public Branch Branch { get; set; }
        public Product Product { get; set; }
        public FinancialYear FinancialYear { get; set; }
    }
    public class Stock : StockDto
    {
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
    }
    internal class StockConfig : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable("Stocks", "public");
            builder.HasKey(e => e.StockId);
            builder.Property(e => e.StockId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_ProductId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.MinQty).HasColumnType("decimal(18, 5)").HasDefaultValue(0.00);
            builder.Property(e => e.MaxQty).HasColumnType("decimal(18, 5)").HasDefaultValue(0.00);
            builder.Property(e => e.OpeningStock).HasColumnType("decimal(18, 2)").HasDefaultValue(0.00);
            builder.Property(e => e.Rate).HasColumnType("decimal(18, 2)").HasDefaultValue(0.00);
            builder.Property(e => e.Amount).HasColumnType("decimal(18, 2)").HasDefaultValue(0.00);
            builder.Property(e => e.AvilableStock).HasColumnType("decimal(18, 2)").HasDefaultValue(0.00);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(bs => bs.Branch).WithMany(b => b.Stocks).HasForeignKey(bs => bs.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bs => bs.Product).WithMany(b => b.Stocks).HasForeignKey(bs => bs.Fk_ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(bs => bs.FinancialYear).WithMany(b => b.Stocks).HasForeignKey(bs => bs.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
