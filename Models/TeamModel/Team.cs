using AmazingTeamTaskManager.Core.Models.MemberModel;
using AmazingTeamTaskManager.Core.Models.TaskFromPlanModel;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AmazingTeamTaskManager.Core.Models.TeamModel
{
    public class Team
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual List<Member> Members { get; set; }
        [JsonIgnore]
        public virtual List<TaskFromPlan> Tasks { get; set; }
    }
}
