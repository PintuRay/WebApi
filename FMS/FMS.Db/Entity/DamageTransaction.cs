﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FMS.Db.Entity
{
    public class DamageTransactionModel
    {     
        public Guid Fk_DamageOrderId { get; set; }
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid Fk_ProductId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
    public class DamageTransaction : DamageTransactionModel
    {
        public Guid DamageTransactionId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public DamageOrder DamageOrder { get; set; }
        public Product Product { get; set; }
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
    }
    internal class DamageTransactionConfig : IEntityTypeConfiguration<DamageTransaction>
    {
        public void Configure(EntityTypeBuilder<DamageTransaction> builder)
        {
            builder.ToTable("DamageTransactions", "dbo");
            builder.HasKey(e => e.DamageTransactionId);
            builder.Property(e => e.DamageTransactionId).ValueGeneratedOnAdd().HasDefaultValueSql("NEWID()");
            builder.Property(e => e.Fk_DamageOrderId).IsRequired(true);
            builder.Property(e => e.TransactionDate).HasColumnType("datetime").IsRequired(true);
            builder.Property(e => e.TransactionNo).IsRequired(true);
            builder.Property(e => e.Fk_ProductId).IsRequired(true);
            builder.Property(e => e.Fk_BranchId).IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).IsRequired(true);
            builder.Property(e => e.Quantity).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.Rate).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.Amount).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasOne(p => p.DamageOrder).WithMany(po => po.DamageTransactions).HasForeignKey(po => po.Fk_DamageOrderId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Product).WithMany(po => po.DamageTransactions).HasForeignKey(po => po.Fk_ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Branch).WithMany(po => po.DamageTransactions).HasForeignKey(po => po.Fk_BranchId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.FinancialYear).WithMany(po => po.DamageTransactions).HasForeignKey(po => po.Fk_FinancialYearId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
