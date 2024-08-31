using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class ProductGroupModel
    {
        public string ProductGroupName { get; set; }
        public Guid Fk_ProductTypeId { get; set; }
    }
    public class ProductGroup : ProductGroupModel
    {
        public Guid ProductGroupId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public ProductType ProductType { get; set; }
        public ICollection<ProductSubGroup> ProductSubGroups { get; set; }
        public ICollection<Product> Products { get; set; }
    }
    internal class ProductGroupConfig : IEntityTypeConfiguration<ProductGroup>
    {
        public void Configure(EntityTypeBuilder<ProductGroup> builder)
        {
            builder.ToTable("ProductGroups", "dbo");
            builder.HasKey(e => e.ProductGroupId);
            builder.Property(e => e.ProductGroupId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.ProductGroupName).HasMaxLength(500).IsRequired(true);
            builder.Property(e => e.Fk_ProductTypeId).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasOne(p => p.ProductType).WithMany(po => po.ProductGroups).HasForeignKey(po => po.Fk_ProductTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
