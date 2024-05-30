using AmazingTeamTaskManager.Core.Models.NotificationModel;
using MongoDB.Driver;

namespace AmazingTeamTaskManager.Core.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>
    {
        public NotificationRepository(IMongoClient client, string databaseName)
            : base(client, databaseName, "Notifications")
        {
        }
    }
}
