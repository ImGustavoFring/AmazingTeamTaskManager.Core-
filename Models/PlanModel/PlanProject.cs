using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazingTeamTaskManager.Core.Models.BaseModel;

namespace AmazingTeamTaskManager.Core.Models.PlanModel
{
    public class PlanProject : IdentifiableEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string PlanId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ProjectId { get; set; }
    }
}
