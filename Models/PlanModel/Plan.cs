using AmazingTeamTaskManager.Core.Models.BaseModel;
using AmazingTeamTaskManager.Core.Models.NotificationModel;
using AmazingTeamTaskManager.Core.Models.ProjectModel;
using AmazingTeamTaskManager.Core.Models.TaskFromPlanModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Models.PlanModel
{
    public class Plan : BaseEntityWithData
    {
        [JsonIgnore]
        public virtual List<Project> Projects { get; set; }
        [JsonIgnore]
        public virtual List<TaskFromPlan> TaskFromPlans { get; set; }
    }
}
