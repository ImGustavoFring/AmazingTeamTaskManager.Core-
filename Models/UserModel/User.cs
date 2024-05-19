using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using AmazingTeamTaskManager.Core.Models.ProfleModel;
using AmazingTeamTaskManager.Core.Models.BaseModel;

namespace AmazingTeamTaskManager.Core.Models.UserModel
{
    public class User : BaseEntity
    {
        public UserRole RoleInSystem { get; set; } = UserRole.USER;
        public string Login { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        [BsonIgnoreIfNull]
        public Profile Profile { get; set; }

    }

    public enum UserRole
    {
        USER,
        ADMIN
    }
}
