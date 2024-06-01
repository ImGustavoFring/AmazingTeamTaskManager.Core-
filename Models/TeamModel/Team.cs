﻿using AmazingTeamTaskManager.Core.Models.MemberModel;
using AmazingTeamTaskManager.Core.Models.ProjectModel;
using AmazingTeamTaskManager.Core.Models.UserModel;
using AmazingTeamTaskManager.Core.Models.NotificationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using AmazingTeamTaskManager.Core.Models.BaseModel;

namespace AmazingTeamTaskManager.Core.Models.TeamModel
{
    public class Team : BaseEntityWithData
    {
        public virtual List<Member> Members { get; set; }
        public virtual List<Project> Projects { get; set; }
    }
}
