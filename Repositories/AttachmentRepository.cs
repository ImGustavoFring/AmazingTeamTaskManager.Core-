using AmazingTeamTaskManager.Core.Models.AttachmentModel;
using MongoDB.Driver;

namespace AmazingTeamTaskManager.Core.Repositories
{
    public class AttachmentRepository : BaseRepository<Attachment>
    {
        public AttachmentRepository(IMongoClient client, string databaseName)
            : base(client, databaseName, "Attachments")
        {
        }
    }
}
