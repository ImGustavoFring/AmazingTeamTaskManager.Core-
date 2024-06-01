using AmazingTeamTaskManager.Core.Contexts;
using AmazingTeamTaskManager.Core.Models.AttachmentModel;

namespace AmazingTeamTaskManager.Core.Repositories.TaskManagerRepositories
{
    public class AttachmentRepository : Repository<TaskManagerDbContext, Attachment>
    {
        public AttachmentRepository(TaskManagerDbContext context) : base(context)
        {
        }
    }
}
