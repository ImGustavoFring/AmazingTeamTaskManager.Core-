using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Models.BaseModel
{
    public class BaseEntityAddition : BaseEntityWithName
    {
        public virtual List<BaseEntityWithName> AnchorLocations { get; set; }
    }
}
