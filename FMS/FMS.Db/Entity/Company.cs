using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Db.Entity
{
    public class CompanyModel
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string GSTIN { get; set; }
        [Required]
        public IFormFile Logo { get; set; }
        public string LogoPath { get; set; }
        [Required]
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_AddressId { get; set; }
        [NotMapped]
        public AddressModel Address { get; set; }
    }
    public class CompanyUpdateModel : CompanyModel
    {
        public Guid CompanyId { get; set; }
        [NotMapped]
        public new AddressUpdateModel Address { get; set; }
    }
    public class CompanyValidator : AbstractValidator<CompanyModel>
    {
        public CompanyValidator()
        {

        }
    }
    public class CompanyDto: CompanyUpdateModel
    {
        public new Address Address { get; set; }
        public Branch Branch { get; set; }
    }
    public class Company : CompanyDto
    {
        public bool? IsActive { get; set; } = true;
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
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
            builder.Property(e => e.LogoPath).IsRequired(true);
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
            builder.HasOne(d => d.Address).WithMany(p => p.Companies).HasForeignKey(d => d.Fk_AddressId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
