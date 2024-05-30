using AmazingTeamTaskManager.Core.Models.ProjectModel;
using MongoDB.Driver;

namespace AmazingTeamTaskManager.Core.Repositories
{
    public class ProjectRepository : BaseRepository<Project>
    {
        public ProjectRepository(IMongoClient client, string databaseName)
            : base(client, databaseName, "Projects")
        {
        }
    }
}
