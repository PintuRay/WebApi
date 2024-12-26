using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Db.Entity
{
    public class ProductModel
    {
        public string ProductName { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal WholeSalePrice { get; set; }
        public decimal GST { get; set; }
        public Guid Fk_ProductTypeId { get; set; }
        public Guid Fk_UnitId { get; set; }
        public Guid Fk_ProductGroupId { get; set; }
        public Guid? Fk_ProductSubGroupId { get; set; }
        [NotMapped]
        public decimal Price {  get; set; }
    }
    public class Product : ProductModel
    {
        public Guid ProductId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public ProductType ProductType { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public ProductSubGroup ProductSubGroup { get; set; }
        public Unit Unit { get; set; }
        public ICollection<AlternateUnit> AlternateUnits { get; set; }
        public ICollection<LabourRate> LabourRates { get; set; }
        //public ICollection<Stock> Stocks { get; set; }
        //public ICollection<LabourOrder> LabourOrders { get; set; }
        //public ICollection<LabourTransaction> LabourTransactions { get; set; }
        //public ICollection<PurchaseTransaction> PurchaseTransactions { get; set; }
        //public ICollection<PurchaseReturnTransaction> PurchaseReturnTransactions { get; set; }
        //public ICollection<SalesTransaction> SalesTransactions { get; set; }
        //public ICollection<SalesReturnTransaction> SalesReturnTransactions { get; set; }
        //public ICollection<InwardSupplyTransaction> InwardSupplyTransactions { get; set; }
        //public ICollection<OutwardSupplyTransaction> OutwardSupplyTransactions { get; set; }
        //public ICollection<DamageTransaction> DamageTransactions { get; set; }
    }
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products", "public");
            builder.HasKey(e => e.ProductId);
            builder.Property(e => e.ProductId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.ProductName).HasMaxLength(200).IsRequired(true);
            builder.Property(e => e.RetailPrice).HasColumnType("decimal(18, 2)").HasDefaultValue(0.00);
            builder.Property(e => e.WholeSalePrice).HasColumnType("decimal(18, 2)").IsRequired(true).HasDefaultValue(0.00);
            builder.Property(e => e.GST).HasColumnType("decimal(18, 2)").HasDefaultValue(0.00);
            builder.Property(e => e.Fk_ProductGroupId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_ProductSubGroupId).HasColumnType("uuid").IsRequired(false);
            builder.Property(e => e.Fk_ProductTypeId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_UnitId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.HasOne(d => d.ProductGroup).WithMany(e => e.Products).HasForeignKey(d => d.Fk_ProductGroupId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.ProductSubGroup).WithMany(e => e.Products).HasForeignKey(d => d.Fk_ProductSubGroupId).OnDelete(DeleteBehavior.Cascade).IsRequired(false);
            builder.HasOne(d => d.ProductType).WithMany(e => e.Products).HasForeignKey(d => d.Fk_ProductTypeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.Unit).WithMany(e => e.Products).HasForeignKey(d => d.Fk_UnitId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
