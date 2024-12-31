﻿using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class CountryModel
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
    public class CountryUpdateModel : CountryModel
    {
        public Guid CountryId { get; set; }
    }
    public class Country : CountryUpdateModel
    {
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public ICollection<State> States { get; set; }
        public ICollection<Dist> Dists { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
    public class CountryValidator : AbstractValidator<CountryModel>
    {
        public CountryValidator()
        {

        }
    }
    internal class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country", "public");
            builder.HasKey(e => e.CountryId);
            builder.Property(e => e.CountryId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.CountryCode).HasMaxLength(3).IsRequired(true);
            builder.Property(e => e.CountryName).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.HasData(
             new Country { CountryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), CountryCode = "IN", CountryName = "India", IsActive = true, CreatedDate = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc) }
         );
        }
    }
}
