using AmazingTeamTaskManager.Core.Contexts;
using AmazingTeamTaskManager.Core.Models.TeamModel;

namespace AmazingTeamTaskManager.Core.Repositories.TaskManagerRepositories
{
    public class TeamRepository : Repository<TaskManagerDbContext, Team>
    {
        public TeamRepository(TaskManagerDbContext context) : base(context)
        {
        }
    }
}
