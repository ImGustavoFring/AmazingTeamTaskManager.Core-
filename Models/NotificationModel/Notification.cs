﻿using AmazingTeamTaskManager.Core.Models.TaskFromPlanModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Models.NotificationModel
{
    public class Notification
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public virtual List<TaskFromPlan> Tasks { get; set; }
    }
}
