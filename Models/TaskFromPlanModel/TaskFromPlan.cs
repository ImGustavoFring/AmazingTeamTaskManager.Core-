using AmazingTeamTaskManager.Core.Models.BaseModel;
using AmazingTeamTaskManager.Core.Models.MemberModel;
using AmazingTeamTaskManager.Core.Models.NotificationModel;
using AmazingTeamTaskManager.Core.Models.PlanModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Models.TaskFromPlanModel
{
    public class TaskFromPlan : BaseEntityWithData
    {
        public DateTime? DeadLineStart { get; set; } = null;
        public DateTime? DeadLineEnd { get; set; } = null;
        public TaskFromPlanPriority Priority { get; set; } = TaskFromPlanPriority.MEDIUM;
        public TaskFromPlanStatus Status { get; set; } = TaskFromPlanStatus.NEW;
        public virtual List<Plan> Plans { get; set; }
        public virtual List<Member> Members { get; set; }
    }

    public enum TaskFromPlanPriority
    {
        VERY_LOW,
        LOW,
        MEDIUM,
        HIGH,
        VERY_HIGH
    }

    public enum TaskFromPlanStatus
    {
        NEW,
        IN_PROGRESS,
        COMPLETED,
        NOT_COMPLETED,
        CANCELLED
    }
}
