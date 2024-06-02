using AmazingTeamTaskManager.Core.Contexts;
using AmazingTeamTaskManager.Core.Models.ProfleModel;
using AmazingTeamTaskManager.Core.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Repositories.TaskManagerRepositories
{
    public class ProfileRepository : Repository<TaskManagerDbContext, Profile>
    {
        public ProfileRepository(TaskManagerDbContext context) : base(context)
        {
        }
    }
}
