using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class SalesOrderSetupModel
    {
        [Required]
        public Guid Fk_FinishedGoodId { get; set; }
        public List<SalesTransactionSetupModel> SalesTransactionSetups { get; set; }
    }
    public class SalesOrderSetupUpdateModel
    {
        [Required]
        public Guid SalesOrderSetupId { get; set; }
        [Required]
        public Guid Fk_FinishedGoodId { get; set; }
        public  List<SalesTransactionSetupUpdateModel> SalesTransactionSetups { get; set; }
    }
    public class SalesOrderSetupDto
    {
        public Guid SalesOrderSetupId { get; set; }
        public Guid Fk_FinishedGoodId { get; set; }
        public string FinishedGoodName { get; set; }
        public List<SalesTransactionSetupDto> SalesTransactionSetups { get; set; } 
    }
    public class SalesOrderSetup
    {
        public Guid SalesOrderSetupId { get; set; }
        public Guid Fk_FinishedGoodId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Product Product { get; set; }
        public  ICollection<SalesTransactionSetup> SalesTransactionSetups { get; set; }
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
