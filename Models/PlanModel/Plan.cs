using AmazingTeamTaskManager.Core.Models.BaseModel;
using AmazingTeamTaskManager.Core.Models.NotificationModel;
using AmazingTeamTaskManager.Core.Models.ProjectModel;
using AmazingTeamTaskManager.Core.Models.TaskFromPlanModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Models.PlanModel
{
    public class Plan : BaseEntityWithData
    {
        public virtual List<Project> Projects { get; set; }
        public virtual List<TaskFromPlan> TaskFromPlans { get; set; }
    }
}
