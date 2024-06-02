using AmazingTeamTaskManager.Core.Contexts;
using AmazingTeamTaskManager.Core.Models.UserModel;

namespace AmazingTeamTaskManager.Core.Repositories.UserDbRepositories
{
    public class UserRepository : Repository<TaskManagerDbContext, User>
    {
        public UserRepository(TaskManagerDbContext context) : base(context)
        {
        }
    }
}
