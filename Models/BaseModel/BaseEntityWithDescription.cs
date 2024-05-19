using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Models.BaseModel
{
    public class BaseEntityWithDescription : BaseEntity
    {
        public string Description { get; set; }
    }
}
