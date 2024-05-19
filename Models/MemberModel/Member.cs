using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazingTeamTaskManager.Core.Models.BaseModel;


namespace AmazingTeamTaskManager.Core.Models.MemberModel
{
    public class Member : IdentifiableEntity
    {
        public MemberRole RoleOnTeam { get; set; } = MemberRole.WORKER;

        [BsonRepresentation(BsonType.ObjectId)]
        public string ProfileId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string TeamId { get; set; }
        public List<MemberTaskFromPlan> Tasks { get; set; }
    }

    public enum MemberRole
    {
        WORKER,
        MANAGER,
        LEADER
    }
}
