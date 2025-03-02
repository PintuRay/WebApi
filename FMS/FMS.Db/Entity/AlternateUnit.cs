using FluentValidation;
using FMS.Db.CustomVaidator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class AlternateUnitModel
    {
        [Required]
        public Guid FK_ProductId { get; set; }
        [Required]
        public string AlternateUnitName { get; set; }
        [Required]
        public Guid Fk_UnitId { get; set; }
        [Required]
        public decimal UnitQuantity { get; set; }
        [Required]
        public decimal AlternateQuantity { get; set; }
    }
    public class AlternateUnitValidator : AbstractValidator<AlternateUnitModel>
    {
        public AlternateUnitValidator(CustomValidation vaidator)
        {

        }
    }
    public class AlternateUnitUpdateModel 
    {
        [Required]
        public Guid AlternateUnitId { get; set; }
        [Required]
        public Guid FK_ProductId { get; set; }
        [Required]
        public string AlternateUnitName { get; set; }
        [Required]
        public Guid Fk_UnitId { get; set; }
        [Required]
        public decimal UnitQuantity { get; set; }
        [Required]
        public decimal AlternateQuantity { get; set; }
    }
    public class AlternateUnitUpdateValidator : AbstractValidator<AlternateUnitUpdateModel>
    {
        public AlternateUnitUpdateValidator(CustomValidation vaidator)
        {

        }
    }
    public class AlternateUnitDto
    {
        public Guid AlternateUnitId { get; set; }
        public Guid FK_ProductId { get; set; }
        public string AlternateUnitName { get; set; }
        public Guid Fk_UnitId { get; set; }
        public decimal UnitQuantity { get; set; }
        public decimal AlternateQuantity { get; set; }
    }
    public class AlternateUnit 
    {
        public Guid AlternateUnitId { get; set; }
        public Guid FK_ProductId { get; set; }
        public string AlternateUnitName { get; set; }
        public Guid Fk_UnitId { get; set; }
        public decimal UnitQuantity { get; set; }
        public decimal AlternateQuantity { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Product Product { get; set; }
        public Unit Unit { get; set; }
        public ICollection<ProductionTransactionSetup> ProductionTransactionSetups { get; set; }
        public ICollection<SalesTransactionSetup> SalesTransactionSetups { get; set; }
        public ICollection<ProductionTransaction> ProductionTransactions { get; set; }
        public ICollection<DamageTransaction> DamageTransactions { get; set; }
        public ICollection<PurchaseTransaction> PurchaseTransactions { get; set; }
        public ICollection<PurchaseReturnTransaction> PurchaseReturnTransactions { get; set; }
        public ICollection<SalesTransaction> SalesTransactions { get; set; }
        public ICollection<SalesReturnTransaction> SalesReturnTransactions { get; set; }
    }
    internal class AlternateUnitConfig : IEntityTypeConfiguration<AlternateUnit>
    {
        public void Configure(EntityTypeBuilder<AlternateUnit> builder)
        {
            builder.ToTable("AlternateUnits", "public");
            builder.HasKey(e => e.AlternateUnitId);
            builder.Property(e => e.AlternateUnitId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.FK_ProductId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_UnitId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.AlternateQuantity).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.UnitQuantity).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
           builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(p => p.Product).WithMany(po => po.AlternateUnits).HasForeignKey(po => po.FK_ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Unit).WithMany(po => po.AlternateUnits).HasForeignKey(po => po.Fk_UnitId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
//UNIT
//----
//ID NAME
// 1  KGS
// 2  BAGS
// 3  GRAM

//ALTERNATE UNIT
//--------------

//ID | PRODUCT-ID | UNITID   | STOCK_UNIT (When set product)
//-----------------------------------
//1  | 1 (RICE)   | 1 (KGS)  |1    (KGS)
//2  | 1 (RICE)   | 2 (BAGS) |25   (KGS)
//3  | 1 (RICE)   | 3 (GRAM) |0.001(KGS) 