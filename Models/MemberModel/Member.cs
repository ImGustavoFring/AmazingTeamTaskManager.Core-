using AmazingTeamTaskManager.Core.Models.BaseModel;
using AmazingTeamTaskManager.Core.Models.ProfleModel;
using AmazingTeamTaskManager.Core.Models.TaskFromPlanModel;
using AmazingTeamTaskManager.Core.Models.TeamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Models.MemberModel
{
    public class Member : BaseEntity
    {
        public Guid ProfileId { get; set; }
        public Profile Profile { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
        public virtual List<TaskFromPlan> TaskFromPlans { get; set; }
        public RoleOnTeam Role { get; set; } = RoleOnTeam.WORKER;
    }

    public enum RoleOnTeam
    {
        WORKER,
        MANAGER,
        LEADER
    }
}
