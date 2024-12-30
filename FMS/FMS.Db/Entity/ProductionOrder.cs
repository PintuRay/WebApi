﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class ProductionOrderModel
    {
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Fk_LabourId { get; set; }
        public decimal OTAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public string Narration { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public Guid FK_BranchId { get; set; }
        public ICollection<ProductionTransaction> ProductionTransactions { get; set; }
    }
    public class ProductionOrderUpdateModel : ProductionOrderModel
    {
        public Guid ProductionOrderId { get; set; }
    }

    public class ProductionOrder: ProductionOrderUpdateModel
    {
        public bool  IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Labour Labour { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public Branch Branch { get; set; }
    }
    public class LabourOrderValidator : AbstractValidator<ProductionOrderModel>
    {
        public LabourOrderValidator()
        {

        }
    }

    internal class ProductionOrderConfig : IEntityTypeConfiguration<ProductionOrder>
    {
        public void Configure(EntityTypeBuilder<ProductionOrder> builder)
        {
            builder.ToTable("ProductionOrders", "public");
            builder.HasKey(e => e.ProductionOrderId);
            builder.Property(e => e.ProductionOrderId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.TransactionNo).IsRequired(true);
            builder.Property(e => e.Fk_LabourId).IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.FK_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.TransactionDate).HasColumnType("timestamptz").IsRequired(true);
            builder.Property(e => e.OTAmount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.Narration).IsRequired(false);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.HasOne(l => l.Labour).WithMany(pe => pe.ProductionOrders).HasForeignKey(e => e.Fk_LabourId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(f => f.FinancialYear).WithMany(pe => pe.ProductionOrders).HasForeignKey(e => e.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Branch).WithMany(pe => pe.ProductionOrders).HasForeignKey(e => e.FK_BranchId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
