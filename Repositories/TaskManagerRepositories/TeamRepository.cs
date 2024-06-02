using AmazingTeamTaskManager.Core.Contexts;
using AmazingTeamTaskManager.Core.Models.TeamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Repositories.TaskManagerRepositories
{
    public class TeamRepository : Repository<TaskManagerDbContext, Team>
    {
        public TeamRepository(TaskManagerDbContext context) : base(context)
        {
        }
    }
}
