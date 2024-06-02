using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.DTOs.TaskManagerDTOs
{
    public class UpdateTaskFromPlanDeadlinesDTO
    {
        public DateTime? NewDeadlineStart { get; set; }
        public DateTime? NewDeadlineEnd { get; set; }
    }
}
