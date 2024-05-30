using AmazingTeamTaskManager.Core.Models.TaskFromPlanModel;
using MongoDB.Driver;

namespace AmazingTeamTaskManager.Core.Repositories
{
    public class TaskFromPlanRepository : BaseRepository<TaskFromPlan>
    {
        public TaskFromPlanRepository(IMongoClient client, string databaseName)
            : base(client, databaseName, "TasksFromPlan")
        {
        }
    }
}
