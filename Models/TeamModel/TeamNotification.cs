using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using AmazingTeamTaskManager.Core.Models.BaseModel;

namespace AmazingTeamTaskManager.Core.Models.TeamModel
{
    public class TeamNotification : IdentifiableEntity
    {

        [BsonRepresentation(BsonType.ObjectId)]
        public string TeamId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string NotificationId { get; set; }
    }
}