using AmazingTeamTaskManager.Core.Models.UserModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(IMongoClient client, string databaseName)
            : base(client, databaseName, "Users")
        {
        }
    }
}
