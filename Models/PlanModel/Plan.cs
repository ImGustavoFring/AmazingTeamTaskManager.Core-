using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazingTeamTaskManager.Core.Models.TaskFromPlanModel;
using AmazingTeamTaskManager.Core.Models.BaseModel;

namespace AmazingTeamTaskManager.Core.Models.PlanModel
{
    public class Plan : BaseEntityWithName
    {
        public List<PlanProject> Projects { get; set; }
        public List<TaskFromPlanPlan> Tasks { get; set; }
    }
}
