﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class OutwardSupplyTransactionModel
    {
        public Guid Fk_OutwardSupplyOrderId { get; set; }
        public Guid Fk_ProductId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
    public class OutwardSupplyTransactionUpdateModel : OutwardSupplyTransactionModel
    {
        public Guid OutwardSupplyTransactionId { get; set; }
    }
    public class OutwardSupplyTransaction : OutwardSupplyTransactionUpdateModel
    {
        public bool IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public OutwardSupplyOrder OutwardSupplyOrder { get; set; }
        public Product Product { get; set; }
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
    }
    public class OutwardSupplyTransactionValidator : AbstractValidator<OutwardSupplyTransactionModel>
    {
        public OutwardSupplyTransactionValidator()
        {

        }
    }

    internal class OutwardSupplyTransactionConfig : IEntityTypeConfiguration<OutwardSupplyTransaction>
    {
        public void Configure(EntityTypeBuilder<OutwardSupplyTransaction> builder)
        {
            builder.ToTable("OutwardSupplyTransactions", "public");
            builder.HasKey(e => e.OutwardSupplyTransactionId);
            builder.Property(e => e.OutwardSupplyTransactionId).ValueGeneratedOnAdd().HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_OutwardSupplyOrderId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_ProductId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Quantity).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.Rate).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.Amount).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.HasOne(p => p.OutwardSupplyOrder).WithMany(po => po.OutwardSupplyTransactions).HasForeignKey(po => po.Fk_OutwardSupplyOrderId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Product).WithMany(po => po.OutwardSupplyTransactions).HasForeignKey(po => po.Fk_ProductId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Branch).WithMany(po => po.OutwardSupplyTransactions).HasForeignKey(po => po.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.FinancialYear).WithMany(po => po.OutwardSupplyTransactions).HasForeignKey(po => po.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}