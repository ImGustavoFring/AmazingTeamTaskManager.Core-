using AmazingTeamTaskManager.Core.Contexts;
using AmazingTeamTaskManager.Core.Models.AttachmentModel;

namespace AmazingTeamTaskManager.Core.Repositories.TaskManagerRepositories
{
    public class TaskAttachmentRepository : Repository<TaskManagerDbContext, TaskAttachment>
    {
        public TaskAttachmentRepository(TaskManagerDbContext context) : base(context)
        {
        }
    }
}
