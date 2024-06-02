using AmazingTeamTaskManager.Core.Models.MemberModel;
using AmazingTeamTaskManager.Core.Models.TeamModel;
using AmazingTeamTaskManager.Core.Repositories.TaskManagerRepositories;
using AmazingTeamTaskManager.Core.Services.TaskManagerServices.AmazingTeamTaskManager.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Services
{
    public class TeamService : BaseService<Team, TeamRepository>
    {
        private readonly MemberRepository _memberRepository;

        public TeamService(TeamRepository repository, MemberRepository memberRepository) : base(repository)
        {
            _memberRepository = memberRepository;
        }

        public override async Task AddRelatedAsync(Guid teamId, Guid memberId)
        {
            var member = await _memberRepository.GetOneAsync(m => m.Id == memberId);
            if (member == null)
            {
                throw new Exception("Member not found.");
            }

            await _repository.UpdateOneAsync(t => t.Id == teamId, team =>
            {
                if (team.Members == null)
                {
                    team.Members = new List<Member>();
                }
                team.Members.Add(member);
                team.UpdatedAt = DateTime.UtcNow;
            });
        }

        public override async Task<IEnumerable<Guid>> ReadRelatedAsync(Guid teamId)
        {
            var team = await _repository.GetOneAsync(t => t.Id == teamId);
            if (team == null || team.Members == null)
            {
                return Enumerable.Empty<Guid>();
            }
            return team.Members.Select(m => m.Id);
        }

        public override async Task DeleteRelatedAsync(Guid teamId, Guid memberId)
        {
            await _repository.UpdateOneAsync(t => t.Id == teamId, team =>
            {
                var member = team.Members.FirstOrDefault(m => m.Id == memberId);
                if (member != null)
                {
                    team.Members.Remove(member);
                    team.UpdatedAt = DateTime.UtcNow;
                }
            });
        }
    }
}
