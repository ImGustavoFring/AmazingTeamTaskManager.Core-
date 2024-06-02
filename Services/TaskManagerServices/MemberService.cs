using AmazingTeamTaskManager.Core.Models.MemberModel;
using AmazingTeamTaskManager.Core.Models.TaskFromPlanModel;
using AmazingTeamTaskManager.Core.Repositories.TaskManagerRepositories;
using AmazingTeamTaskManager.Core.Services.TaskManagerServices.AmazingTeamTaskManager.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Services
{
    public class MemberService : BaseService<Member, MemberRepository>
    {
        private readonly TaskFromPlanRepository _taskFromPlanRepository;

        public MemberService(MemberRepository repository, TaskFromPlanRepository taskFromPlanRepository) : base(repository)
        {
            _taskFromPlanRepository = taskFromPlanRepository;
        }

        public override async Task AddRelatedAsync(Guid memberId, Guid taskFromPlanId)
        {
            var taskFromPlan = await _taskFromPlanRepository.GetOneAsync(t => t.Id == taskFromPlanId);
            if (taskFromPlan == null)
            {
                throw new Exception("TaskFromPlan not found.");
            }

            await _repository.UpdateOneAsync(m => m.Id == memberId, member =>
            {
                if (member.TaskFromPlans == null)
                {
                    member.TaskFromPlans = new List<TaskFromPlan>();
                }
                member.TaskFromPlans.Add(taskFromPlan);
                member.UpdatedAt = DateTime.UtcNow;
            });
        }

        public override async Task<IEnumerable<Guid>> ReadRelatedAsync(Guid memberId)
        {
            var member = await _repository.GetOneAsync(m => m.Id == memberId);
            if (member == null || member.TaskFromPlans == null)
            {
                return Enumerable.Empty<Guid>();
            }
            return member.TaskFromPlans.Select(t => t.Id);
        }

        public override async Task DeleteRelatedAsync(Guid memberId, Guid taskFromPlanId)
        {
            await _repository.UpdateOneAsync(m => m.Id == memberId, member =>
            {
                var taskFromPlan = member.TaskFromPlans.FirstOrDefault(t => t.Id == taskFromPlanId);
                if (taskFromPlan != null)
                {
                    member.TaskFromPlans.Remove(taskFromPlan);
                    member.UpdatedAt = DateTime.UtcNow;
                }
            });
        }
    }
}
