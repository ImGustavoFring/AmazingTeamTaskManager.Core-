using AmazingTeamTaskManager.Core.Contexts;
using AmazingTeamTaskManager.Core.Models.ProjectModel;

namespace AmazingTeamTaskManager.Core.Repositories.TaskManagerRepositories
{
    public class ProjectRepository : Repository<TaskManagerDbContext, Project>
    {
        public ProjectRepository(TaskManagerDbContext context) : base(context)
        {
        }
    }
}
