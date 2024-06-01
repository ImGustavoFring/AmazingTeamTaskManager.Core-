using AmazingTeamTaskManager.Core.Contexts;
using AmazingTeamTaskManager.Core.Models.TaskFromPlanModel;

namespace AmazingTeamTaskManager.Core.Repositories.TaskManagerRepositories
{
    public class TaskFromPlanRepository : Repository<TaskManagerDbContext, TaskFromPlan>
    {
        public TaskFromPlanRepository(TaskManagerDbContext context) : base(context)
        {
        }
    }
}
