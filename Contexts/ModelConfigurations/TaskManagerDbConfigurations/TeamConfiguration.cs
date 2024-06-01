using AmazingTeamTaskManager.Core.Models.TeamModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazingTeamTaskManager.Core.Contexts.ModelConfigurations.TaskManagerDbConfigurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);

            builder.HasIndex(t => t.Name).IsUnique();

            builder.Property(t => t.Name).IsRequired();
            builder.Property(t => t.Description).IsRequired();

            builder.HasMany(t => t.Members)
                   .WithOne(m => m.Team)
                   .HasForeignKey(m => m.TeamId);
        }
    }
}
