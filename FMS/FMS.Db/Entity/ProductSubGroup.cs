﻿using FluentValidation;
using FMS.Db.CustomVaidator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class ProductSubGroupModel
    {
        [Required]
        public Guid Fk_ProductGroupId { get; set; }
        [Required]
        public string ProductSubGroupName { get; set; }
    }
    public class ProductSubGroupValidator : AbstractValidator<ProductSubGroupModel>
    {
        public ProductSubGroupValidator(CustomValidation vaidator)
        {

        }
    }
    public class ProductSubGroupUpdateModel
    {
        [Required]
        public Guid ProductSubGroupId { get; set; }
        [Required]
        public Guid Fk_ProductGroupId { get; set; }
        [Required]
        public string ProductSubGroupName { get; set; }
    }
    public class ProductSubGroupUpdateValidator : AbstractValidator<ProductSubGroupUpdateModel>
    {
        public ProductSubGroupUpdateValidator(CustomValidation vaidator)
        {

        }
    }
    public class ProductSubGroupDto
    {
        public Guid ProductSubGroupId { get; set; }
        public Guid Fk_ProductGroupId { get; set; }
        public string ProductSubGroupName { get; set; }
    }
    public class ProductSubGroup
    {
        public Guid ProductSubGroupId { get; set; }
        public Guid Fk_ProductGroupId { get; set; }
        public string ProductSubGroupName { get; set; }
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
            builder.ToTable("ProductSubGroups", "public");
            builder.HasKey(e => e.ProductSubGroupId);
            builder.Property(e => e.ProductSubGroupId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_ProductGroupId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.ProductSubGroupName).HasMaxLength(200).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(s => s.ProductGroup).WithMany(t => t.ProductSubGroups).HasForeignKey(s => s.Fk_ProductGroupId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
