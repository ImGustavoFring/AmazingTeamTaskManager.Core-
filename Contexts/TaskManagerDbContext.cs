using AmazingTeamTaskManager.Core.Contexts.ModelConfigurations.TaskManagerDbConfigurations;
using AmazingTeamTaskManager.Core.Models.MemberModel;
using AmazingTeamTaskManager.Core.Models.NotificationModel;
using AmazingTeamTaskManager.Core.Models.PlanModel;
using AmazingTeamTaskManager.Core.Models.ProjectModel;
using AmazingTeamTaskManager.Core.Models.TaskFromPlanModel;
using AmazingTeamTaskManager.Core.Models.TeamModel;
using AmazingTeamTaskManager.Core.Models.AttachmentModel;
using Microsoft.EntityFrameworkCore;

namespace AmazingTeamTaskManager.Core.Contexts
{
    public class TaskManagerDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<TaskFromPlan> TaskFromPlans { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

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
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new PlanConfiguration());
            modelBuilder.ApplyConfiguration(new TaskFromPlanConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new AttachmentConfiguration());
        }
    }
}
