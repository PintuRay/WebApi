using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class StateModel
    {
        public Guid Fk_CounryId { get; set; }
        public string StateName { get; set; }
    }
    public class State : StateModel
    {
        public Guid StateId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public Country Country { get; set; }
        public ICollection<Address> Addresses { get; set; }
        //public ICollection<Party> Parties { get; set; }
        public ICollection<Dist> Dists { get; set; }
    }
    internal class StateConfig : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("States", "public");
            builder.HasKey(e => e.StateId);
            builder.Property(e => e.StateId).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.StateName).HasMaxLength(100).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValue(DateTime.UtcNow); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValue(DateTime.UtcNow); 
            builder.HasOne(c => c.Country).WithMany(s => s.States).HasForeignKey(c => c.Fk_CounryId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
             new State { StateId = Guid.Parse("67C9F3A9-9235-428A-8463-A743F711A5A3"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Andhra Pradesh", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("E691660F-BB06-416A-A79C-9EF41E67AD11"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Arunachal Pradesh", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("970EC112-CE5E-4F5B-9707-BE75C379D803"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Assam", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("9F0240BA-79FA-47C5-86F6-E4F3D2EE10D8"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Bihar", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("188AB651-AF96-41D2-ADC4-0AF044E6D056"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Chhattisgarh", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("B4B9ACF3-87A2-4F5F-95A0-872C0680FB1E"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Goa", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("2316471C-4FC5-43EE-B20C-94E5C5775514"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Gujarat", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("D1459E60-A200-440A-9862-6A6C26BF37EA"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Haryana", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("E7C6A407-A7F8-4711-B8FF-E57D7B93CAFA"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Himachal Pradesh", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("B176F1FE-DABA-406F-9256-E6EE6ECD52ED"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Jharkhand", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("B2D8B019-F729-4BAC-8006-9B46A307153C"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Karnataka", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("D84EAAE8-09FB-4D80-9303-D166529BDE20"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Kerala", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("5ED4F9B3-F38A-4AE9-A738-6F1B3EE50A88"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Madhya Pradesh", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("802047BC-496C-4A69-A786-5BA566F8B06B"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Maharashtra", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("1F2AD09E-7095-4050-B653-AE2D5693FB22"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Manipur", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("A14644A8-9C2F-4AA6-8332-9CB576C4DC8C"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Meghalaya", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("9A41572B-AC7A-4234-AF77-6D6E426E88EF"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Mizoram", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("6AD24792-A695-43BA-89E3-EDA8C1FD7A20"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Nagaland", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("2D1EA7CB-CF85-4BE6-BDDA-422E99BEA59E"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Odisha", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("65AFD736-C385-4F57-B667-DE4E77F4C9D5"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Punjab", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("2B525373-AFCC-4FB1-9525-495DB02029F8"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Rajasthan", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("AD98660A-F208-4194-82FA-9E74747B2A02"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Sikkim", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("C2D0C6C5-6954-4921-9D64-90261DE50F5E"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Tamil Nadu", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("43D58903-126E-4ACA-8289-B3D09C7A1E14"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Telangana", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("2898A196-C192-40B6-9865-F7AA4018681C"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Tripura", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("F20C53DC-BA9A-4FD6-82CD-63C76FB11CC5"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Uttar Pradesh", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("4A49B1DC-6F18-4DE7-85EC-46563A4B5B56"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Uttarakhand", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("559B5985-BDD4-4DAB-8AA7-1887EF7B2C98"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "West Bengal", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("FC5486FE-AA06-46F0-9D93-B6A4F71429A2"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Dadra and Nagar Haveli (UT)", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("EAF9A3CC-A650-429E-BCC5-406257614DFA"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Daman & Diu (UT)", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("77536C53-345C-48F5-A175-07A7B4044754"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Jammu & Kashmir (UT)", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("C9FBD62C-A7FC-4F5E-A44E-2C9FFFE94C8F"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Ladakh (UT)", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("DB5157FD-B616-418B-82E9-3D5F109D69F8"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Chandigarh (UT)", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("022DF470-AAA9-4F6D-895A-75F41906F76A"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Delhi (UT)", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("DF18BE70-0BA6-4918-8351-BF992E4EE17A"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Puducherry (UT)", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("4ECAFA26-9EB1-47A6-A927-A23F8F3C4833"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Lakshadweep (UT)", IsActive = true, CreatedDate = DateTime.UtcNow },
             new State { StateId = Guid.Parse("ABE258B7-A358-42CC-8CCE-657DFE4D6644"), Fk_CounryId = Guid.Parse("E02EB064-DEF5-434A-8798-6F144A54003C"), StateName = "Andaman and Nicobar Islands (UT)", IsActive = true, CreatedDate = DateTime.UtcNow }
       );
        }
    }
}
