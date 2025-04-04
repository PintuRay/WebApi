﻿using FluentValidation;
using FMS.Db.CustomVaidator;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class OutwardSupplyOrderModel
    {
        [Required]
        public string TransactionNo { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public Guid ToBranch { get; set; }
        [Required]
        public Guid Fk_ProductTypeId { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public List<OutwardSupplyTransactionModel> OutwardSupplyTransactions { get; set; }
    }
    public class OutwardSupplyOrderValidator : AbstractValidator<OutwardSupplyOrderModel>
    {
        public OutwardSupplyOrderValidator(CustomValidation vaidator)
        {

        }
    }
    public class OutwardSupplyOrderUpdateModel 
    {
        [Required]
        public Guid OutwardSupplyOrderId { get; set; }
        [Required]
        public string TransactionNo { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public Guid ToBranch { get; set; }
        [Required]
        public Guid Fk_ProductTypeId { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        [Required]
        public Guid Fk_FinancialYearId { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        public List<OutwardSupplyTransactionUpdateModel> OutwardSupplyTransactions { get; set; }
    }
    public class OutwardSupplyOrderUpdateValidator : AbstractValidator<OutwardSupplyOrderUpdateModel>
    {
        public OutwardSupplyOrderUpdateValidator(CustomValidation vaidator)
        {

        }
    }
    public class OutwardSupplyOrderDto 
    {
        public Guid OutwardSupplyOrderId { get; set; }
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid ToBranch { get; set; }
        public Guid Fk_ProductTypeId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OutwardSupplyTransactionUpdateModel> OutwardSupplyTransactions { get; set; }
    }
    public class OutwardSupplyOrder
    {
        public Guid OutwardSupplyOrderId { get; set; }
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid ToBranch { get; set; }
        public Guid Fk_ProductTypeId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal TotalAmount { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
        public ProductType ProductType { get; set; }
        public ICollection<OutwardSupplyTransaction> OutwardSupplyTransactions { get; set; }
    }
    internal class OutwardSupplyOrderConfig : IEntityTypeConfiguration<OutwardSupplyOrder>
    {
        public void Configure(EntityTypeBuilder<OutwardSupplyOrder> builder)
        {
            builder.ToTable("OutwardSupplyOrders", "public");
            builder.HasKey(e => e.OutwardSupplyOrderId);
            builder.Property(e => e.OutwardSupplyOrderId).ValueGeneratedOnAdd().HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.TransactionDate).HasColumnType("timestamptz").IsRequired(true);
            builder.Property(e => e.TransactionNo).IsRequired(true);
            builder.Property(e => e.ToBranch).IsRequired(true);
            builder.Property(e => e.Fk_ProductTypeId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(p => p.ProductType).WithMany(po => po.OutwardSupplyOrders).HasForeignKey(po => po.Fk_ProductTypeId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Branch).WithMany(po => po.OutwardSupplyOrders).HasForeignKey(po => po.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.FinancialYear).WithMany(po => po.OutwardSupplyOrders).HasForeignKey(po => po.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
