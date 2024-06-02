using AmazingTeamTaskManager.Core.Models.PlanModel;
using AmazingTeamTaskManager.Core.Models.ProjectModel;
using AmazingTeamTaskManager.Core.Repositories.TaskManagerRepositories;
using AmazingTeamTaskManager.Core.Services.TaskManagerServices.AmazingTeamTaskManager.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Services
{
    public class PlanService : BaseService<Plan, PlanRepository>
    {
        private readonly ProjectRepository _projectRepository;

        public PlanService(PlanRepository repository, ProjectRepository projectRepository) : base(repository)
        {
            _projectRepository = projectRepository;
        }

        public override async Task AddRelatedAsync(Guid planId, Guid projectId)
        {
            var project = await _projectRepository.GetOneAsync(p => p.Id == projectId);
            if (project == null)
            {
                throw new Exception("Project not found.");
            }

            await _repository.UpdateOneAsync(p => p.Id == planId, plan =>
            {
                if (plan.Projects == null)
                {
                    plan.Projects = new List<Project>();
                }
                plan.Projects.Add(project);
                plan.UpdatedAt = DateTime.UtcNow;
            });
        }

        public override async Task<IEnumerable<Guid>> ReadRelatedAsync(Guid planId)
        {
            var plan = await _repository.GetOneAsync(p => p.Id == planId);
            if (plan == null || plan.Projects == null)
            {
                return Enumerable.Empty<Guid>();
            }
            return plan.Projects.Select(p => p.Id);
        }

        public override async Task DeleteRelatedAsync(Guid planId, Guid projectId)
        {
            await _repository.UpdateOneAsync(p => p.Id == planId, plan =>
            {
                var project = plan.Projects.FirstOrDefault(p => p.Id == projectId);
                if (project != null)
                {
                    plan.Projects.Remove(project);
                    plan.UpdatedAt = DateTime.UtcNow;
                }
            });
        }
    }
}
