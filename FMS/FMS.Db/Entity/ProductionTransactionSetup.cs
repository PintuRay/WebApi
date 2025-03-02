using FluentValidation;
using FMS.Db.CustomVaidator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Db.Entity
{
    public class ProductionTransactionSetUpModel
    {
        [Required]
        public Guid Fk_ProductionOrderSetupId { get; set; }
        [Required]
        public Guid Fk_RawMaterialId { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public Guid Fk_AlternateUnitId { get; set; }
    }
    public class ProductionTransactionSetupValidator : AbstractValidator<ProductionTransactionSetUpModel>
    {
        public ProductionTransactionSetupValidator(CustomValidation vaidator)
        {

        }
    }
    public class ProductionTransactionSetUpUpdateModel
    {
        [Required]
        public Guid ProductionTransactionSetupId { get; set; }
        [Required]
        public Guid Fk_ProductionOrderSetupId { get; set; }
        [Required]
        public Guid Fk_RawMaterialId { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        [Required]
        public Guid Fk_AlternateUnitId { get; set; }
    }
    public class ProductionTransactionSetupUpUpdateValidator : AbstractValidator<ProductionTransactionSetUpUpdateModel>
    {
        public ProductionTransactionSetupUpUpdateValidator(CustomValidation vaidator)
        {

        }
    }
    public class ProductionTransactionSetupDto
    {
        public Guid ProductionTransactionSetupId { get; set; }
        public Guid Fk_ProductionOrderSetupId { get; set; }
        public Guid Fk_RawMaterialId { get; set; }
        public decimal Quantity { get; set; }
        public Guid Fk_AlternateUnitId { get; set; }
        public string RawMaterialName { get; set; }
    }
    public class ProductionTransactionSetup
    {
        public Guid ProductionTransactionSetupId { get; set; }
        public Guid Fk_ProductionOrderSetupId { get; set; }
        public Guid Fk_RawMaterialId { get; set; }
        public decimal Quantity { get; set; }
        public Guid Fk_AlternateUnitId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public ProductionOrderSetup ProductionOrderSetup { get; set; }
        public Product Product { get; set; }
        public AlternateUnit AlternateUnit { get; set; }
    }
    internal class ProductionTransactionSetupConfig : IEntityTypeConfiguration<ProductionTransactionSetup>
    {
        public void Configure(EntityTypeBuilder<ProductionTransactionSetup> builder)
        {
            builder.ToTable("ProductionTransactionSetups", "public");
            builder.HasKey(e => e.ProductionTransactionSetupId);
            builder.Property(e => e.ProductionTransactionSetupId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_RawMaterialId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Quantity).HasColumnType("decimal(18, 5)").IsRequired(true);
            builder.Property(e => e.Fk_AlternateUnitId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(e => e.ProductionOrderSetup).WithMany(s => s.ProductionTransactionSetups).HasForeignKey(e => e.Fk_ProductionOrderSetupId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Product).WithMany(s => s.ProductionTransactionSetups).HasForeignKey(e => e.Fk_RawMaterialId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.AlternateUnit).WithMany(s => s.ProductionTransactionSetups).HasForeignKey(e => e.Fk_AlternateUnitId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
