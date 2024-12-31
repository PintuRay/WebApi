using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Db.Entity
{
    public class ProductionTransactionSetUpModel
    {
        public Guid Fk_ProductionOrderSetupId {  get; set; }
        public Guid Fk_RawMaterialId { get; set; }
        public decimal Quantity { get; set; }
        public Guid Fk_AlternateUnitId { get; set; }
    }
    public class ProductionTransactionSetUpUpdateModel : ProductionTransactionSetUpModel
    {
        public Guid ProductionTransactionSetupId { get; set; }
    }
    public class ProductionTransactionSetup: ProductionTransactionSetUpUpdateModel
    {
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public ProductionOrderSetup ProductionOrderSetup { get; set; }
        [NotMapped]
        public string RawMaterialName { get; set; }
        public Product Product { get; set; }
       public AlternateUnit AlternateUnit { get; set; }
    }
    public class ProductionTransactionSetupValidator : AbstractValidator<ProductionTransactionSetUpModel>
    {
        public ProductionTransactionSetupValidator()
        {

        }
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
