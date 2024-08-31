using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class ProductSubGroupModel
    {
        public Guid Fk_ProductGroupId { get; set; }
        public string ProductSubGroupName { get; set; }
    }
    public class ProductSubGroup : ProductSubGroupModel
    {
        public Guid ProductSubGroupId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public ProductGroup ProductGroup { get; set; }
        public ICollection<Product> Products { get; set; }
    }
    internal class ProductSubGroupConfig : IEntityTypeConfiguration<ProductSubGroup>
    {
        public void Configure(EntityTypeBuilder<ProductSubGroup> builder)
        {
            builder.ToTable("ProductSubGroups", "dbo");
            builder.HasKey(e => e.ProductSubGroupId);
            builder.Property(e => e.ProductSubGroupId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_ProductGroupId).IsRequired(true);
            builder.Property(e => e.ProductSubGroupName).HasMaxLength(200).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasOne(s => s.ProductGroup).WithMany(t => t.ProductSubGroups).HasForeignKey(s => s.Fk_ProductGroupId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
