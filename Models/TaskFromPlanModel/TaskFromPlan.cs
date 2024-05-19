using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using AmazingTeamTaskManager.Core.Models.MemberModel;
using AmazingTeamTaskManager.Core.Models.BaseModel;

namespace AmazingTeamTaskManager.Core.Models.TaskFromPlanModel
{
    public class TaskFromPlan : BaseEntityWithName
    {

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? DeadLineStart { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? DeadLineEnd { get; set; }

        public TaskPriority Priority { get; set; } = TaskPriority.NORMAL;

        public TaskStatus Status { get; set; } = TaskStatus.NEW;

        public List<TaskFromPlanPlan> Plans { get; set; }
        public List<MemberTaskFromPlan> Members { get; set; }
    }

    public enum TaskPriority
    {
        VERY_LOW,
        LOW,
        NORMAL,
        HIGH,
        VERY_HIGH
    }

    public enum TaskStatus
    {
        NEW,
        IN_PROGRESS,
        COMPLETED,
        NOT_COMPLETED,
        CANCELLED
    }
}
