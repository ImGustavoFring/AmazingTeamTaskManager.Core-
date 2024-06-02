using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Models.BaseModel
{
    public class BaseEntityAddition : BaseEntityWithName
    {
        [JsonIgnore]
        public virtual List<BaseEntityWithName> AnchorLocations { get; set; }
    }
}
