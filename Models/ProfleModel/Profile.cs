using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using AmazingTeamTaskManager.Core.Models.MemberModel;
using AmazingTeamTaskManager.Core.Models.BaseModel;

namespace AmazingTeamTaskManager.Core.Models.ProfleModel
{
    public class Profile : BaseEntityWithDescription
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [BsonIgnore]
        public string UserId { get; set; }

        public List<Member> Members { get; set; }
    }
}
