using AmazingTeamTaskManager.Core.Models.ProfleModel;
using MongoDB.Driver;

namespace AmazingTeamTaskManager.Core.Repositories
{
    public class ProfileRepository : BaseRepository<Profile>
    {
        public ProfileRepository(IMongoClient client, string databaseName)
            : base(client, databaseName, "Profiles")
        {
        }
    }
}
