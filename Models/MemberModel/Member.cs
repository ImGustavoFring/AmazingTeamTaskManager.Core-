using AmazingTeamTaskManager.Core.Models.ProfleModel;
using AmazingTeamTaskManager.Core.Models.TaskFromPlanModel;
using AmazingTeamTaskManager.Core.Models.TeamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Models.MemberModel
{
    public class Member
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public Guid ProfileId { get; set; }
        [JsonIgnore]
        public virtual Profile Profile { get; set; }
        public Guid TeamId { get; set; }
        [JsonIgnore]
        public virtual Team Team { get; set; }
        [JsonIgnore]
        public virtual List<TaskFromPlan> Tasks{ get; set; }
        public RoleOnTeam Role { get; set; } = RoleOnTeam.WORKER;
    }

    public enum RoleOnTeam
    {
        WORKER,
        MANAGER,
        LEADER
    }
}
