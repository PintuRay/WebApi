using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class SalesOrderSetupModel
    {
        public Guid Fk_FinishedGoodId { get; set; }
        public ICollection<SalesTransactionSetup> SalesTransactionSetups { get; set; }
    }
    public class SalesOrderSetup : SalesOrderSetupModel
    {
        public Guid SalesOrderSetupId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
    }
    public class SalesOrderSetupConfig : IEntityTypeConfiguration<SalesOrderSetup>
    {
        public void Configure(EntityTypeBuilder<SalesOrderSetup> builder)
        {
            builder.ToTable("SalesOrderSetups", "dbo");
            builder.HasKey(e => e.SalesOrderSetupId);
            builder.Property(e => e.SalesOrderSetupId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.Fk_FinishedGoodId).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
        }
    }
}
