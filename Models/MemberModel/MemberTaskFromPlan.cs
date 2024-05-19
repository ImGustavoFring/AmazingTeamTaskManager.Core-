﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazingTeamTaskManager.Core.Models.BaseModel;

namespace AmazingTeamTaskManager.Core.Models.MemberModel
{
    public class MemberTaskFromPlan : IdentifiableEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string MemberId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string TaskFromPlanId { get; set; }
    }
}
