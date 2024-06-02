using AmazingTeamTaskManager.Core.Models.PlanModel;
using AmazingTeamTaskManager.Core.Models.TaskFromPlanModel;
using AmazingTeamTaskManager.Core.Models.MemberModel;
using AmazingTeamTaskManager.Core.Repositories.TaskManagerRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmazingTeamTaskManager.Core.Services.TaskManagerServices.AmazingTeamTaskManager.Core.Services;

namespace AmazingTeamTaskManager.Core.Services
{
    public class TaskFromPlanService : BaseService<TaskFromPlan, TaskFromPlanRepository>
    {
        private readonly PlanRepository _planRepository;
        private readonly MemberRepository _memberRepository;

        public TaskFromPlanService(TaskFromPlanRepository repository, PlanRepository planRepository, MemberRepository memberRepository) : base(repository)
        {
            _planRepository = planRepository;
            _memberRepository = memberRepository;
        }

        public override async Task AddRelatedAsync(Guid taskFromPlanId, Guid relatedId)
        {
            var plan = await _planRepository.GetOneAsync(p => p.Id == relatedId);
            var member = await _memberRepository.GetOneAsync(m => m.Id == relatedId);

            if (plan == null && member == null)
            {
                throw new Exception("Related entity not found.");
            }

            await _repository.UpdateOneAsync(t => t.Id == taskFromPlanId, taskFromPlan =>
            {
                if (plan != null)
                {
                    if (taskFromPlan.Plans == null)
                    {
                        taskFromPlan.Plans = new List<Plan>();
                    }
                    taskFromPlan.Plans.Add(plan);
                }
                if (member != null)
                {
                    if (taskFromPlan.Members == null)
                    {
                        taskFromPlan.Members = new List<Member>();
                    }
                    taskFromPlan.Members.Add(member);
                }
                taskFromPlan.UpdatedAt = DateTime.UtcNow;
            });
        }

        public override async Task<IEnumerable<Guid>> ReadRelatedAsync(Guid taskFromPlanId)
        {
            var taskFromPlan = await _repository.GetOneAsync(t => t.Id == taskFromPlanId);
            if (taskFromPlan == null)
            {
                return Enumerable.Empty<Guid>();
            }

            var relatedIds = new List<Guid>();
            if (taskFromPlan.Plans != null)
            {
                relatedIds.AddRange(taskFromPlan.Plans.Select(p => p.Id));
            }
            if (taskFromPlan.Members != null)
            {
                relatedIds.AddRange(taskFromPlan.Members.Select(m => m.Id));
            }

            return relatedIds;
        }

        public override async Task DeleteRelatedAsync(Guid taskFromPlanId, Guid relatedId)
        {
            await _repository.UpdateOneAsync(t => t.Id == taskFromPlanId, taskFromPlan =>
            {
                var plan = taskFromPlan.Plans?.FirstOrDefault(p => p.Id == relatedId);
                if (plan != null)
                {
                    taskFromPlan.Plans.Remove(plan);
                }
                var member = taskFromPlan.Members?.FirstOrDefault(m => m.Id == relatedId);
                if (member != null)
                {
                    taskFromPlan.Members.Remove(member);
                }
                taskFromPlan.UpdatedAt = DateTime.UtcNow;
            });
        }
    }
}
