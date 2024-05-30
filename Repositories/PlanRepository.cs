using AmazingTeamTaskManager.Core.Models.PlanModel;
using MongoDB.Driver;

namespace AmazingTeamTaskManager.Core.Repositories
{
    public class PlanRepository : BaseRepository<Plan>
    {
        public PlanRepository(IMongoClient client, string databaseName)
            : base(client, databaseName, "Plans")
        {
        }
    }
}
