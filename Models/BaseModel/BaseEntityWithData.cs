using AmazingTeamTaskManager.Core.Models.AttachmentModel;
using AmazingTeamTaskManager.Core.Models.NotificationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Models.BaseModel
{
    public class BaseEntityWithData : BaseEntityWithName
    {
        [JsonIgnore]
        public virtual List<BaseEntityAddition> Notifications { get; set; }
        [JsonIgnore]
        public virtual List<BaseEntityAddition> Attachments { get; set; }
    }
}
