using AmazingTeamTaskManager.Core.Models.ProjectModel;
using AmazingTeamTaskManager.Core.Models.TeamModel;
using AmazingTeamTaskManager.Core.Repositories.TaskManagerRepositories;
using AmazingTeamTaskManager.Core.Services.TaskManagerServices.AmazingTeamTaskManager.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Services
{
    public class ProjectService : BaseService<Project, ProjectRepository>
    {
        private readonly TeamRepository _teamRepository;

        public ProjectService(ProjectRepository repository, TeamRepository teamRepository) : base(repository)
        {
            _teamRepository = teamRepository;
        }

        public override async Task AddRelatedAsync(Guid projectId, Guid teamId)
        {
            var team = await _teamRepository.GetOneAsync(t => t.Id == teamId);
            if (team == null)
            {
                throw new Exception("Team not found.");
            }

            await _repository.UpdateOneAsync(p => p.Id == projectId, project =>
            {
                if (project.Teams == null)
                {
                    project.Teams = new List<Team>();
                }
                project.Teams.Add(team);
                project.UpdatedAt = DateTime.UtcNow;
            });
        }

        public override async Task<IEnumerable<Guid>> ReadRelatedAsync(Guid projectId)
        {
            var project = await _repository.GetOneAsync(p => p.Id == projectId);
            if (project == null || project.Teams == null)
            {
                return Enumerable.Empty<Guid>();
            }
            return project.Teams.Select(t => t.Id);
        }

        public override async Task DeleteRelatedAsync(Guid projectId, Guid teamId)
        {
            await _repository.UpdateOneAsync(p => p.Id == projectId, project =>
            {
                var team = project.Teams.FirstOrDefault(t => t.Id == teamId);
                if (team != null)
                {
                    project.Teams.Remove(team);
                    project.UpdatedAt = DateTime.UtcNow;
                }
            });
        }
    }
}
