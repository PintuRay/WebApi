using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FMS.Db.Entity
{
    public class UserBranchModel
    {
        public string Fk_UserId { get; set; }
        public Guid Fk_BranchId { get; set; }
    }
    public class UserBranch: UserBranchModel
    {
        public Guid Id { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string CreatedBy { get; set; } = null;
        public string ModifyBy { get; set; } = null;
        //Navigation Property
        public AppUser User { get; set; }
        public Branch Branch { get; set; }
    }
    internal class UserBranchConfig : IEntityTypeConfiguration<UserBranch>
    {
        public void Configure(EntityTypeBuilder<UserBranch> builder)
        {
            builder.ToTable("UserBranches", "public");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            builder.Property(e => e.Fk_BranchId).HasColumnType("uuid").IsRequired(true);
            builder.Property(e => e.Fk_UserId).IsRequired(true);
            builder.Property(e => e.IsActive).HasDefaultValueSql("true");
            builder.Property(e => e.CreatedBy).HasMaxLength(100);
            builder.Property(e => e.CreatedDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            builder.Property(e => e.ModifyBy).HasMaxLength(100);
            builder.Property(e => e.ModifyDate).HasColumnType("timestamptz").HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'"); 
            //One-To-Many Relationship
            builder.HasOne(ub => ub.User).WithMany(u => u.UserBranch).HasForeignKey(ub => ub.Fk_UserId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ub => ub.Branch).WithMany(b => b.UserBranch).HasForeignKey(ub => ub.Fk_BranchId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
