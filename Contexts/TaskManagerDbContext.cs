using AmazingTeamTaskManager.Core.Contexts.ModelConfigurations.TaskManagerDbConfigurations;
using AmazingTeamTaskManager.Core.Models.MemberModel;
using AmazingTeamTaskManager.Core.Models.NotificationModel;
using AmazingTeamTaskManager.Core.Models.TaskFromPlanModel;
using AmazingTeamTaskManager.Core.Models.TeamModel;
using AmazingTeamTaskManager.Core.Models.AttachmentModel;
using AmazingTeamTaskManager.Core.Models.UserModel;
using AmazingTeamTaskManager.Core.Models.ProfleModel;
using Microsoft.EntityFrameworkCore;
using AmazingTeamTaskManager.Core.Contexts.ModelConfigurations.UserDbConfigurations;

namespace AmazingTeamTaskManager.Core.Contexts
{
    public class TaskManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TaskFromPlan> TaskFromPlans { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<TaskAttachment> TaskAttachments { get; set; }

        public TaskManagerDbContext()
        {
            Database.EnsureCreated();
        }

        public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new TaskFromPlanConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new TaskAttachmentConfiguration());
        }
    }
}
