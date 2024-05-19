using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;
using AmazingTeamTaskManager.Core.Models.MemberModel;
using AmazingTeamTaskManager.Core.Models.ProjectModel;
using AmazingTeamTaskManager.Core.Models.BaseModel;

namespace AmazingTeamTaskManager.Core.Models.TeamModel
{
    public class Team : BaseEntityWithName
    {
        public List<MemberModel.Member> Members { get; set; }
        public List<ProjectTeam> Projects { get; set; }
        public List<TeamNotification> Notifications { get; set; }
    }
}
