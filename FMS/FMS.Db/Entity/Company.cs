using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class CompanyModel
    {    
        public Guid Fk_BranchId { get; set; }
        public string CompanyName { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string GSTIN { get; set; }
        public string Logo { get; set; }  
    }
    public class Company : CompanyModel
    {
        public Guid CompanyId { get; set; }
        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        public Branch Branch { get; set; }
    }
    internal class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company", "dbo");
            builder.HasKey(e => e.CompanyId);
            builder.Property(e => e.CompanyId).HasDefaultValueSql("(newid())");
            builder.Property(e => e.CompanyName).HasMaxLength(200).IsRequired(true);
            builder.Property(e => e.Fk_BranchId).IsRequired(true);
            builder.Property(e => e.Logo).IsRequired(true);
            builder.Property(e => e.State).IsRequired(true);
            builder.Property(e => e.Address).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.GSTIN).IsRequired(true);
            builder.Property(e => e.Email).IsRequired(true);
            builder.Property(e => e.PhoneNo).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.HasOne(s => s.Branch).WithMany(e => e.Companies).HasForeignKey(e => e.Fk_BranchId);
        }
    }
}
