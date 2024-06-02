using AmazingTeamTaskManager.Core.Models.BaseModel;
using AmazingTeamTaskManager.Core.Models.NotificationModel;
using AmazingTeamTaskManager.Core.Models.PlanModel;
using AmazingTeamTaskManager.Core.Models.TaskFromPlanModel;
using AmazingTeamTaskManager.Core.Models.TeamModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Models.ProjectModel
{
    public class Project : BaseEntityWithData
    {
        [JsonIgnore]
        public virtual List<Team> Teams { get; set; }
        [JsonIgnore]
        public virtual List<Plan> Plans { get; set; }
    }
}
