using AmazingTeamTaskManager.Core.Contexts;
using AmazingTeamTaskManager.Core.Models.UserModel;

namespace AmazingTeamTaskManager.Core.Repositories.UserDbRepositories
{
    public class UserRepository : Repository<UserDbContext, User>
    {
        public UserRepository(UserDbContext context) : base(context)
        {
        }
    }
}
