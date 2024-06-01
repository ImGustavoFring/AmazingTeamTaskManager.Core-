using AmazingTeamTaskManager.Core.Models.UserModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using AmazingTeamTaskManager.Core.Models.ProfleModel;

namespace AmazingTeamTaskManager.Core.Contexts.ModelConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Login).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Login).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.RoleInSystem).IsRequired();

            builder.Property(u => u.RoleInSystem)
                   .HasConversion(
                       v => v.ToString(),
                       v => (RoleInSystem)Enum.Parse(typeof(RoleInSystem), v));

            builder.HasOne(u => u.Profile)
                   .WithOne(p => p.User)
                   .HasForeignKey<Profile>(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
