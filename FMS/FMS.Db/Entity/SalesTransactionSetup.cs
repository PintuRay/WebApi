using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public string SubFinishedGoodName { get; set; }
        public Product Product { get; set; }
    }
    public class SalesTransactionSetupConfig : IEntityTypeConfiguration<SalesTransactionSetup>
    {
        public void Configure(EntityTypeBuilder<SalesTransactionSetup> builder)
        {
            builder.ToTable("SalesTransactionSetups", "public");
            builder.HasKey(e => e.SalesTransactionSetupId);
            builder.Property(e => e.SalesTransactionSetupId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_SubFinishedGoodId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.Quantity).HasColumnType("decimal(18, 5)").IsRequired(true);
            builder.Property(e => e.Unit).HasMaxLength(100).IsRequired(true);
            builder.HasOne(s=>s.SalesOrderSetup).WithMany(s=>s.SalesTransactionSetups).HasForeignKey(d => d.Fk_SalesOrderSetupId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(e => e.Product).WithMany(s => s.SalesTransactionSetups).HasForeignKey(e => e.Fk_SubFinishedGoodId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
