using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class CountryModel
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
    }
    public class Country : CountryModel
    {
        public Guid CountryId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public ICollection<Address> Addresses { get; set; }
        //public ICollection<Party> Parties { get; set; }
        public ICollection<State> States { get; set; }
        public ICollection<Dist> Dists { get; set; }
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
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValue(DateTime.UtcNow); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValue(DateTime.UtcNow); 
            builder.HasData(
             new Country { CountryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), CountryCode = "IN", CountryName = "India", IsActive = true, CreatedDate = DateTime.UtcNow }
           //new Country { CountryId = Guid.NewGuid(), CountryCode = "AX", CountryName = "Åland Islands", IsActive = true, CreatedDate = DateTime.UtcNow },
           //new Country { CountryId = Guid.NewGuid(), CountryCode = "AL", CountryName = "Albania", IsActive = true, CreatedDate = DateTime.UtcNow },
          //new Country { CountryId = Guid.NewGuid(), CountryCode = "ZW", CountryName = "Zimbabwe", IsActive = true, CreatedDate = DateTime.UtcNow }
         );
        }
    }
}
