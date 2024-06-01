using AmazingTeamTaskManager.Core.Models.NotificationModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazingTeamTaskManager.Core.Contexts.ModelConfigurations.TaskManagerDbConfigurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Name).IsRequired();
            builder.Property(n => n.Description).IsRequired();
        }
    }
}
