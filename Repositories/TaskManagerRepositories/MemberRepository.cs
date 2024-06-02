using AmazingTeamTaskManager.Core.Contexts;
using AmazingTeamTaskManager.Core.Models.MemberModel;

namespace AmazingTeamTaskManager.Core.Repositories.TaskManagerRepositories
{
    public class MemberRepository : Repository<TaskManagerDbContext, Member>
    {
        public MemberRepository(TaskManagerDbContext context) : base(context)
        {
        }
    }
}
