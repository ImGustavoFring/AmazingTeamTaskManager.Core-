using AmazingTeamTaskManager.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Models.AttachmentModel
{
    public class Attachment : BaseEntityAddition
    {
        public List<string> FileIDs { get; set; }
    }
}
