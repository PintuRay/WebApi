using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace FMS.Db.Entity
{
    public class ProductionOrderSetupModel
    {
        [Required]
        public Guid Fk_FinishedGoodId { get; set; }
        public List<ProductionTransactionSetUpModel> ProductionTransactionSetups { get; set; }
    }
    public class ProductionOrderSetupUpdateModel
    {
        [Required]
        public Guid ProductionOrderSetupId { get; set; }
        [Required]
        public Guid Fk_FinishedGoodId { get; set; }
        public List<ProductionTransactionSetUpUpdateModel> ProductionTransactionSetups { get; set; }
    }
    public class ProductionOrderSetupDto
    {
        public Guid ProductionOrderSetupId { get; set; }
        public Guid Fk_FinishedGoodId { get; set; }
        public string FinishedGoodName { get; set; }
        public List<ProductionTransactionSetupDto> ProductionTransactionSetups { get; set; }
    }
    public class ProductionOrderSetup
    {
        public Guid ProductionOrderSetupId { get; set; }
        public Guid Fk_FinishedGoodId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Product Product { get; set; }
        public ICollection<ProductionTransactionSetup> ProductionTransactionSetups { get; set; }
    }
    internal class ProductionOrderSetupConfig : IEntityTypeConfiguration<ProductionOrderSetup>
    {
        public void Configure(EntityTypeBuilder<ProductionOrderSetup> builder)
        {
            builder.ToTable("ProductionOrderSetups", "public");
            builder.HasKey(e => e.ProductionOrderSetupId);
            builder.Property(e => e.ProductionOrderSetupId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_FinishedGoodId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
            builder.HasOne(e => e.Product).WithMany(s => s.ProductionOrderSetups).HasForeignKey(e => e.Fk_FinishedGoodId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
