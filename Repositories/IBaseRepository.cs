using AmazingTeamTaskManager.Core.Models.BaseModel;
using MongoDB.Driver;

public interface IBaseRepository<T> where T : IdentifiableEntity
{
    Task AddAsync(T entity);
    Task DeleteManyAsync(Func<FilterDefinitionBuilder<T>, FilterDefinition<T>> filter);
    Task DeleteOneAsync(Func<FilterDefinitionBuilder<T>, FilterDefinition<T>> filter);
    Task<IEnumerable<T>> GetManyAsync(Func<FilterDefinitionBuilder<T>, FilterDefinition<T>> filter = null);
    Task<T> GetOneAsync(Func<FilterDefinitionBuilder<T>, FilterDefinition<T>> filter);
    Task UpdateManyAsync(Func<FilterDefinitionBuilder<T>, FilterDefinition<T>> filter, Action<UpdateDefinitionBuilder<T>> update);
    Task UpdateOneAsync(Func<FilterDefinitionBuilder<T>, FilterDefinition<T>> filter, Action<UpdateDefinitionBuilder<T>> update);
}