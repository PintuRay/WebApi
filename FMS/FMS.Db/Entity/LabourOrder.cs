﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FMS.Db.Entity
{
    public class LabourOrderModel
    {
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid Fk_ProductId { get; set; }
        public Guid Fk_LabourId { get; set; }
        public Guid Fk_LabourTypeId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public Guid FK_BranchId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal OTAmount { get; set; }
        public string Narration { get; set; }
       
    }
    public class LabourOrder: LabourOrderModel
    {
        public Guid LabourOrderId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Product Product { get; set; }
        public Labour Labour { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public Branch Branch { get; set; }
        public LabourType LabourType { get; set; }
        public ICollection<LabourTransaction> LabourTransactions { get; set; }
    }
    internal class LabourOrderConfig : IEntityTypeConfiguration<LabourOrder>
    {
        public void Configure(EntityTypeBuilder<LabourOrder> builder)
        {
            builder.ToTable("LabourOrders", "dbo");
            builder.HasKey(e => e.LabourOrderId);
            builder.Property(e => e.LabourOrderId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.TransactionDate).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.TransactionNo).IsRequired(true);
            builder.Property(e => e.Fk_ProductId).IsRequired(true);
            builder.Property(e => e.Fk_LabourId).IsRequired(true);
            builder.Property(e => e.Fk_LabourTypeId).IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).IsRequired(true);
            builder.Property(e => e.FK_BranchId).IsRequired(true);
            builder.Property(e => e.TransactionDate).HasColumnType("datetime");
            builder.Property(e => e.Quantity).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.Rate).HasColumnType("decimal(18, 4)").HasDefaultValue(0);
            builder.Property(e => e.Amount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.OTAmount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.Narration).IsRequired(false);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasOne(p => p.Product).WithMany(pe => pe.LabourOrders).HasForeignKey(e => e.Fk_ProductId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(l => l.Labour).WithMany(pe => pe.LabourOrders).HasForeignKey(e => e.Fk_LabourId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(f => f.FinancialYear).WithMany(pe => pe.LabourOrders).HasForeignKey(e => e.Fk_FinancialYearId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Branch).WithMany(pe => pe.LabourOrders).HasForeignKey(e => e.FK_BranchId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.LabourType).WithMany(pe => pe.LabourOrders).HasForeignKey(e => e.Fk_LabourTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
