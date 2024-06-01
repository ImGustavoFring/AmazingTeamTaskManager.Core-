using AmazingTeamTaskManager.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task AddOneAsync(T entity);
        Task<T> GetOneAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> filter);
        Task UpdateOneAsync(Expression<Func<T, bool>> filter, Action<T> updateAction);
        Task UpdateManyAsync(Expression<Func<T, bool>> filter, Action<T> updateAction);
        Task DeleteOneAsync(Expression<Func<T, bool>> filter);
        Task DeleteManyAsync(Expression<Func<T, bool>> filter);
    }
}