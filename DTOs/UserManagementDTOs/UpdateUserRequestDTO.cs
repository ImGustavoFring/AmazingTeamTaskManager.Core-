using AmazingTeamTaskManager.Core.Models.ProfleModel;
using AmazingTeamTaskManager.Core.Models.UserModel;

namespace AmazingTeamTaskManager.Core.DTOs.UserManagementDTOs
{
    public class UpdateUserRequestDTO
    {
        public User User { get; set; }
        public Profile Profile { get; set; }
    }
}
