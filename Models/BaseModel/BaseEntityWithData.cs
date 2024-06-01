using AmazingTeamTaskManager.Core.Models.AttachmentModel;
using AmazingTeamTaskManager.Core.Models.NotificationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Models.BaseModel
{
    public class BaseEntityWithData : BaseEntityWithName
    {
        public virtual List<BaseEntityAddition> Notifications { get; set; }
        public virtual List<BaseEntityAddition> Attachments { get; set; }
    }
}
