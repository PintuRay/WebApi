using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class StateModel
    {   
        public string StateName { get; set; }
    }
    public class State: StateModel
    {
        public Guid StateId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        public ICollection<Party> Parties { get; set; }
        public ICollection<City> Cities { get; set; }
    }
    internal class StateConfig : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("States", "dbo");
            builder.HasKey(e => e.StateId);
            builder.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("datetime");
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("datetime");
            builder.Property(e => e.StateId).HasDefaultValueSql("(newid())").IsRequired(true);
            builder.Property(e => e.StateName).HasMaxLength(100).IsRequired(true);
        }
    }
}
