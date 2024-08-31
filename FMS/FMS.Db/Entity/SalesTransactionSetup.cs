using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class SalesTransactionSetupModel
    {
        public Guid Fk_SalesOrderSetupId {  get; set; }
        public Guid Fk_SubFinishedGoodId { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
    }
    public class SalesTransactionSetup : SalesTransactionSetupModel
    {
        public Guid SalesTransactionSetupId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public SalesOrderSetup SalesOrderSetup { get; set; }
    }
    public class SalesTransactionSetupConfig : IEntityTypeConfiguration<SalesTransactionSetup>
    {
        public void Configure(EntityTypeBuilder<SalesTransactionSetup> builder)
        {
            builder.ToTable("SalesTransactionSetups", "dbo");
            builder.HasKey(e => e.SalesTransactionSetupId);
            builder.Property(e => e.SalesTransactionSetupId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_SubFinishedGoodId).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.Property(e => e.Quantity).HasColumnType("decimal(18, 5)").IsRequired(true);
            builder.Property(e => e.Unit).HasMaxLength(100).IsRequired(true);
            builder.HasOne(s=>s.SalesOrderSetup).WithMany(s=>s.SalesTransactionSetups).HasForeignKey(d => d.Fk_SalesOrderSetupId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
