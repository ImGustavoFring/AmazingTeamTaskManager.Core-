using AmazingTeamTaskManager.Core.Contexts.ModelConfigurations;
using AmazingTeamTaskManager.Core.Contexts.ModelConfigurations.UserDbConfigurations;
using AmazingTeamTaskManager.Core.Models.ProfleModel;
using AmazingTeamTaskManager.Core.Models.UserModel;
using Microsoft.EntityFrameworkCore;

namespace AmazingTeamTaskManager.Core.Contexts
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public UserDbContext()
        {
            Database.EnsureCreated();
        }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
        }
    }
}
