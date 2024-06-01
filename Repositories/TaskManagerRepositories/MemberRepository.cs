using AmazingTeamTaskManager.Core.Contexts;
using AmazingTeamTaskManager.Core.Models.MemberModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Repositories.TaskManagerRepositories
{
    public class MemberRepository : Repository<TaskManagerDbContext, Member>
    {
        public MemberRepository(TaskManagerDbContext context) : base(context)
        {
        }
    }
}
