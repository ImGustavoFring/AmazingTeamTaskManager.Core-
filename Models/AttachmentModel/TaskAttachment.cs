using AmazingTeamTaskManager.Core.Models.TaskFromPlanModel;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AmazingTeamTaskManager.Core.Models.AttachmentModel
{
    public class TaskAttachment
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual List<TaskFromPlan> Tasks { get; set; }
        public List<string> FileIDs { get; set; }
    }
}
