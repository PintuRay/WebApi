using FMS.Db.Entity;
using FMS.Db.EntityConfig;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace FMS.Db
{
    public partial class Context : IdentityDbContext<AppUser, AppRole, string>
    {
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        #region Entity
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }
        public DbSet<RegisterToken> RegisterTokens { get; set; }
        public DbSet<FinancialYear> FinancialYears { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchFinancialYear> BranchFinancialYears { get; set; }
        public DbSet<UserBranch> UserBranches { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            #region EntityConfig
            new RegisterTokenConfig().Configure(modelBuilder.Entity<RegisterToken>());
            new AppUserConfig().Configure(modelBuilder.Entity<AppUser>());
            new AppRoleConfig().Configure(modelBuilder.Entity<AppRole>());
            new AppUserRoleConfig().Configure(modelBuilder.Entity<AppUserRole>());
            new FinancialYearConfig().Configure(modelBuilder.Entity<FinancialYear>());
            new BranchConfig().Configure(modelBuilder.Entity<Branch>());
            new BranchFinancialYearConfig().Configure(modelBuilder.Entity<BranchFinancialYear>());
            new UserBranchConfig().Configure(modelBuilder.Entity<UserBranch>());
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}

