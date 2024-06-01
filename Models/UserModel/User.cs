using AmazingTeamTaskManager.Core.Models.BaseModel;
using AmazingTeamTaskManager.Core.Models.ProfleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Models.UserModel
{
    public class User : BaseEntity
    { 
        public string Login { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public RoleInSystem RoleInSystem { get; set; } = RoleInSystem.USER;
        public virtual Profile Profile { get; set; }
    }

    public enum RoleInSystem
    {
        USER,
        ADMIN
    }
}
