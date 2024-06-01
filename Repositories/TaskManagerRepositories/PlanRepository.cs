using AmazingTeamTaskManager.Core.Contexts;
using AmazingTeamTaskManager.Core.Models.PlanModel;

namespace AmazingTeamTaskManager.Core.Repositories.TaskManagerRepositories
{
    public class PlanRepository : Repository<TaskManagerDbContext, Plan>
    {
        public PlanRepository(TaskManagerDbContext context) : base(context)
        {
        }
    }
}
