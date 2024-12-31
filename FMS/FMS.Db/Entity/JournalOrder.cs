﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class JournalOrderModel
    {
        public string VouvherNo { get; set; }
        public DateTime VoucherDate { get; set; }
        public string Narration { get; set; }
        public decimal TotalAmount { get; set; }
        public string DrCr {  get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public ICollection<JournalTransaction> JournalTransactions { get; set; }
    }
    public class JournalOrderUpdateModel : JournalOrderModel
    {
        public Guid JournalOrderId { get; set; }
    }

    public class JournalOrder: JournalOrderUpdateModel
    {
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
    }
    public class JournalOrderValidator : AbstractValidator<JournalOrderModel>
    {
        public JournalOrderValidator()
        {

        }
    }
    internal class JournalOrderConfig : IEntityTypeConfiguration<JournalOrder>
    {
        public void Configure(EntityTypeBuilder<JournalOrder> builder)
        {
            builder.ToTable("JournalOrders", "public");
            builder.HasKey(e => e.JournalOrderId);
            builder.Property(e => e.JournalOrderId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.VouvherNo).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.VoucherDate).HasColumnType("timestamptz").IsRequired(true);
            builder.Property(e => e.Narration).HasMaxLength(500).IsRequired(false);
            builder.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)").HasDefaultValue(0);
            builder.Property(e => e.DrCr).HasMaxLength(10).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_FinancialYearId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
           builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.HasOne(e => e.Branch).WithMany(s => s.JournalOrders).HasForeignKey(e => e.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.FinancialYear).WithMany(s => s.JournalOrders).HasForeignKey(e => e.Fk_FinancialYearId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
