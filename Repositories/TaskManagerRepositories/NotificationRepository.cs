using AmazingTeamTaskManager.Core.Contexts;
using AmazingTeamTaskManager.Core.Models.NotificationModel;

namespace AmazingTeamTaskManager.Core.Repositories.TaskManagerRepositories
{
    public class NotificationRepository : Repository<TaskManagerDbContext, Notification>
    {
        public NotificationRepository(TaskManagerDbContext context) : base(context)
        {
        }
    }
}
