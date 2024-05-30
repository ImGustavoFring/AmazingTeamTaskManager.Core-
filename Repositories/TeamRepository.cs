using AmazingTeamTaskManager.Core.Models.TeamModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Repositories
{
    public class TeamRepository : BaseRepository<Team>
    {
        public TeamRepository(IMongoClient client, string databaseName)
            : base(client, databaseName, "Teams")
        {
        }
    }
}
