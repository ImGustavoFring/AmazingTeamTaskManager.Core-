using AmazingTeamTaskManager.Core.Models.MemberModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazingTeamTaskManager.Core.Contexts.ModelConfigurations.TaskManagerDbConfigurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Profile)
                   .WithMany()
                   .HasForeignKey(m => m.ProfileId);
        }
    }
}
