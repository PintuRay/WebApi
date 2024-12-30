﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class DamageOrderModel
    {    
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid Fk_ProductTypeId { get; set; }
        public string Fk_LabourId { get; set; } = null;
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal TotalAmount { get; set; }
        public string Reason { get; set; } = null;
        public ICollection<DamageTransaction> DamageTransactions { get; set; }
    }
    public class DamageOrderUpdateModel : DamageOrderModel
    {
        public Guid DamageOrderId { get; set; }
    }
    public class DamageOrder: DamageOrderUpdateModel
    {
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public ProductType ProductType { get; set; }
        public Labour Labour { get; set; }
    }
    public class DamageOrderValidator : AbstractValidator<DamageOrderModel>
    {
        public DamageOrderValidator()
        {

        }
    }
    internal class DamageOrderConfig : IEntityTypeConfiguration<DamageOrder>
    {
        public void Configure(EntityTypeBuilder<DamageOrder> builder)
        {
            builder.ToTable("DamageOrders", "public");
            builder.HasKey(e => e.DamageOrderId);
            builder.Property(e => e.DamageOrderId).ValueGeneratedOnAdd().HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.TransactionDate).HasColumnType("timestamptz").IsRequired(true);
            builder.Property(e => e.TransactionNo).IsRequired(true);
            builder.Property(e => e.Fk_LabourId).IsRequired(false);
            builder.Property(e => e.Fk_ProductTypeId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.Reason).HasMaxLength(100).IsRequired(false);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.HasOne(p => p.ProductType).WithMany(po => po.DamageOrders).HasForeignKey(po => po.Fk_ProductTypeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Labour).WithMany(po => po.DamageOrders).HasForeignKey(po => po.Fk_LabourId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Branch).WithMany(po => po.DamageOrders).HasForeignKey(po => po.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.FinancialYear).WithMany(po => po.DamageOrders).HasForeignKey(po => po.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
