using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class ProductGroupModel
    {
        [Required]
        public string ProductGroupName { get; set; }
        [Required]
        public Guid Fk_ProductTypeId { get; set; }
    }
    public class ProductGroupValidator : AbstractValidator<ProductGroupModel>
    {
        public ProductGroupValidator()
        {

        }
    }
    public class ProductGroupUpdateModel
    {
        [Required]
        public Guid ProductGroupId { get; set; }
        [Required]
        public string ProductGroupName { get; set; }
        [Required]
        public Guid Fk_ProductTypeId { get; set; }
    }
    public class ProductGroupUpdateValidator : AbstractValidator<ProductGroupUpdateModel>
    {
        public ProductGroupUpdateValidator()
        {

        }
    }
    public class ProductGroupDto
    {
        public Guid ProductGroupId { get; set; }
        public string ProductGroupName { get; set; }
        public Guid Fk_ProductTypeId { get; set; }
    }
    public class ProductGroup
    {
        public Guid ProductGroupId { get; set; }
        public string ProductGroupName { get; set; }
        public Guid Fk_ProductTypeId { get; set; }
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
            builder.ToTable("ProductGroups", "public");
            builder.HasKey(e => e.ProductGroupId);
            builder.Property(e => e.ProductGroupId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.ProductGroupName).HasMaxLength(500).IsRequired(true);
            builder.Property(e => e.Fk_ProductTypeId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(p => p.ProductType).WithMany(po => po.ProductGroups).HasForeignKey(po => po.Fk_ProductTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
