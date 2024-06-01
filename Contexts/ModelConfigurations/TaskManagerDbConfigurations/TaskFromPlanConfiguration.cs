using AmazingTeamTaskManager.Core.Models.TaskFromPlanModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazingTeamTaskManager.Core.Contexts.ModelConfigurations.TaskManagerDbConfigurations
{
    public class TaskFromPlanConfiguration : IEntityTypeConfiguration<TaskFromPlan>
    {
        public void Configure(EntityTypeBuilder<TaskFromPlan> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Description).IsRequired();
        }
    }
}
