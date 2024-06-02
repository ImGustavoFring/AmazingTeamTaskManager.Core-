using AmazingTeamTaskManager.Core.Models.BaseModel;
using AmazingTeamTaskManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Services.TaskManagerServices
{
    namespace AmazingTeamTaskManager.Core.Services
    {
        public abstract class BaseService<TEntity,
            TRepository> where TEntity : BaseEntity where TRepository : IRepository<TEntity>
        {
            protected readonly TRepository _repository;

            protected BaseService(TRepository repository)
            {
                _repository = repository;
            }

            public async Task AddAsync(TEntity entity)
            {
                await _repository.AddOneAsync(entity);
            }

            public async Task<TEntity> GetOneByIdAsync(Guid id)
            {
                return await _repository.GetOneAsync(e => e.Id == id);
            }

            public async Task<IEnumerable<TEntity>> GetAllAsync()
            {
                return await _repository.GetManyAsync(e => true);
            }

            public async Task UpdateAsync(Guid id, Action<TEntity> updateAction)
            {
                await _repository.UpdateOneAsync(e => e.Id == id, updateAction);
            }

            public async Task DeleteAsync(Guid id)
            {
                await _repository.DeleteOneAsync(e => e.Id == id);
            }

            public abstract Task AddRelatedAsync(Guid id, Guid relatedId);
            public abstract Task<IEnumerable<Guid>> ReadRelatedAsync(Guid id);
            public abstract Task DeleteRelatedAsync(Guid id, Guid relatedId);
        }
    }
}
