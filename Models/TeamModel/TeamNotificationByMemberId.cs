﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace AmazingTeamTaskManager.Core.Models.TeamModel
{
    public class TeamNotificationByMemberId : TeamNotification
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string MemberId { get; set; }
    }
}