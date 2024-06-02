using AmazingTeamTaskManager.Core.Models.ProfleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Models.UserModel
{
    public class User
    { 
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; } = null;
        public string Login { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public RoleInSystem RoleInSystem { get; set; } = RoleInSystem.USER;
        [JsonIgnore]
        public virtual Profile Profile { get; set; }

    }

    public enum RoleInSystem
    {
        USER,
        ADMIN
    }
}
