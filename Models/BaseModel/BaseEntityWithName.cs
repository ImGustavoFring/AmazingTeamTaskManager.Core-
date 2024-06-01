using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Models.BaseModel
{
    public class BaseEntityWithName : BaseEntityWithDescription
    {
        public string Name { get; set; }
    }
}
