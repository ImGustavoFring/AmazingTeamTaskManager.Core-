using AmazingTeamTaskManager.Core.Models.MemberModel;

namespace AmazingTeamTaskManager.Core.Models.TeamModel
{
    public class TeamNotificationByRole : TeamNotification
    {
        public List<MemberRole> Recipients { get; set; }
    }
}