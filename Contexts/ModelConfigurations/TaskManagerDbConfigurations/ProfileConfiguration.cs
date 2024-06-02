using AmazingTeamTaskManager.Core.Models.ProfleModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AmazingTeamTaskManager.Core.Contexts.ModelConfigurations.UserDbConfigurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.LastName).IsRequired();

            builder.HasOne(p => p.User)
                   .WithOne(u => u.Profile)
                   .HasForeignKey<Profile>(p => p.UserId);

            builder.HasMany(p => p.Members)
                   .WithOne(m => m.Profile)
                   .HasForeignKey(m => m.ProfileId) 
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
