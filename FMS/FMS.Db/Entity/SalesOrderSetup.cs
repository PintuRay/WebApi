using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Db.Entity
{
    public class SalesOrderSetupModel
    {
        [Required]
        public Guid Fk_FinishedGoodId { get; set; }
        [NotMapped]
        public List<SalesTransactionSetupModel> SalesTransactionSetups { get; set; }
    }
    public class SalesOrderSetupUpdateModel : SalesOrderSetupModel
    {
        [Required]
        public Guid SalesOrderSetupId { get; set; }
        [NotMapped]
        public new List<SalesTransactionSetupUpdateModel> SalesTransactionSetups { get; set; }
    }
    public class SalesOrderSetupDto : SalesOrderSetupUpdateModel
    {
        [NotMapped]
        public string FinishedGoodName { get; set; }
        public Product Product { get; set; }
        public new ICollection<SalesTransactionSetup> SalesTransactionSetups { get; set; }
    }
    public class SalesOrderSetup : SalesOrderSetupDto
    {
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
            builder.ToTable("SalesOrderSetups", "public");
            builder.HasKey(e => e.SalesOrderSetupId);
            builder.Property(e => e.SalesOrderSetupId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_FinishedGoodId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(e => e.Product).WithMany(s => s.SalesOrderSetups).HasForeignKey(e => e.Fk_FinishedGoodId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
