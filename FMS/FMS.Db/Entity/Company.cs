using FluentValidation;
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
    public class CompanyUpdateModel : CompanyModel
    {
        public Guid CompanyId { get; set; }
    }
    public class Company : CompanyUpdateModel
    {
        public bool IsActive { get; set; } = true;
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        public Branch Branch { get; set; }
    }
    public class CompanyValidator : AbstractValidator<CompanyModel>
    {
        public CompanyValidator()
        {

        }
    }
    internal class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company", "public");
            builder.HasKey(e => e.CompanyId);
            builder.Property(e => e.CompanyId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.CompanyName).HasMaxLength(200).IsRequired(true);
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Logo).IsRequired(true);
            builder.Property(e => e.State).IsRequired(true);
            builder.Property(e => e.Address).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.GSTIN).IsRequired(true);
            builder.Property(e => e.Email).IsRequired(true);
            builder.Property(e => e.PhoneNo).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.HasOne(s => s.Branch).WithMany(e => e.Companies).HasForeignKey(e => e.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
