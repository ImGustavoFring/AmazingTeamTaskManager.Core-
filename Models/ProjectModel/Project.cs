using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazingTeamTaskManager.Core.Models.NotificationModel;
using AmazingTeamTaskManager.Core.Models.PlanModel;
using AmazingTeamTaskManager.Core.Models.BaseModel;

namespace AmazingTeamTaskManager.Core.Models.ProjectModel
{
    public class Project : BaseEntityWithName
    {
        public List<ProjectTeam> Teams { get; set; }
        public List<PlanProject> Plans { get; set; }
    }
}
