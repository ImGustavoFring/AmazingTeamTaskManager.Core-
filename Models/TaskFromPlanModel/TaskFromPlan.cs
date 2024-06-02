using AmazingTeamTaskManager.Core.Models.AttachmentModel;
using AmazingTeamTaskManager.Core.Models.MemberModel;
using AmazingTeamTaskManager.Core.Models.NotificationModel;
using AmazingTeamTaskManager.Core.Models.TeamModel;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.Json.Serialization;

namespace AmazingTeamTaskManager.Core.Models.TaskFromPlanModel
{
    public class TaskFromPlan
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Project { get; set; }
        public string Plan { get; set; }
        public DateTime? DeadLineStart { get; set; } = null;
        public DateTime? DeadLineEnd { get; set; } = null;
        public TaskFromPlanPriority Priority { get; set; } = TaskFromPlanPriority.MEDIUM;
        public TaskFromPlanStatus Status { get; set; } = TaskFromPlanStatus.NEW;
        [JsonIgnore]
        public virtual List<Member> Members { get; set; }
        [JsonIgnore]
        public virtual List<Team> Teams { get; set; }
        [JsonIgnore]
        public virtual List<Notification> Notifications { get; set; }
        [JsonIgnore]
        public virtual List<TaskAttachment> Attachments { get; set; }
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
