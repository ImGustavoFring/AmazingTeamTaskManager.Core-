using AmazingTeamTaskManager.Core.Models.BaseModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class BaseRepository<T> : IBaseRepository<T> where T : IdentifiableEntity
{
    private readonly IMongoCollection<T> _collection;

    public BaseRepository(IMongoClient client, string databaseName, string collectionName)
    {
        var database = client.GetDatabase(databaseName);
        _collection = database.GetCollection<T>(collectionName);
    }

    public async Task AddAsync(T entity)
    {
        try
        {
            await _collection.InsertOneAsync(entity);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error while adding entity.", ex);
        }
    }

    public async Task<T> GetOneAsync(Func<FilterDefinitionBuilder<T>, FilterDefinition<T>> filter)
    {
        if (filter == null)
        {
            throw new ArgumentNullException(nameof(filter), "Filter cannot be null for GetOneAsync.");
        }

        try
        {
            var filterDefinition = filter(Builders<T>.Filter);
            return await _collection.Find(filterDefinition).FirstOrDefaultAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error while retrieving entity.", ex);
        }
    }

    public async Task<IEnumerable<T>> GetManyAsync(Func<FilterDefinitionBuilder<T>, FilterDefinition<T>> filter = null)
    {
        try
        {
            FilterDefinition<T> filterDefinition;
            if (filter == null)
            {
                filterDefinition = Builders<T>.Filter.Empty;
            }
            else
            {
                filterDefinition = filter(Builders<T>.Filter);
            }
            return await _collection.Find(filterDefinition).ToListAsync();
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error while retrieving entities.", ex);
        }
    }

    public async Task UpdateOneAsync(Func<FilterDefinitionBuilder<T>, FilterDefinition<T>> filter, Action<UpdateDefinitionBuilder<T>> update)
    {
        if (filter == null)
        {
            throw new ArgumentNullException(nameof(filter), "Filter cannot be null for UpdateOneAsync.");
        }

        try
        {
            var filterDefinition = filter(Builders<T>.Filter);
            var updateDefinitionBuilder = Builders<T>.Update;
            var updateDefinition = updateDefinitionBuilder.Combine();
            update(updateDefinitionBuilder);
            await _collection.UpdateOneAsync(filterDefinition, updateDefinition);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error while updating entity.", ex);
        }
    }

    public async Task UpdateManyAsync(Func<FilterDefinitionBuilder<T>, FilterDefinition<T>> filter, Action<UpdateDefinitionBuilder<T>> update)
    {
        try
        {
            FilterDefinition<T> filterDefinition;
            if (filter == null)
            {
                filterDefinition = Builders<T>.Filter.Empty;
            }
            else
            {
                filterDefinition = filter(Builders<T>.Filter);
            }

            var updateDefinitionBuilder = Builders<T>.Update;
            var updateDefinition = updateDefinitionBuilder.Combine();
            update(updateDefinitionBuilder);
            await _collection.UpdateManyAsync(filterDefinition, updateDefinition);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error while updating entities.", ex);
        }
    }

    public async Task DeleteOneAsync(Func<FilterDefinitionBuilder<T>, FilterDefinition<T>> filter)
    {
        if (filter == null)
        {
            throw new ArgumentNullException(nameof(filter), "Filter cannot be null for DeleteOneAsync.");
        }

        try
        {
            var filterDefinition = filter(Builders<T>.Filter);
            await _collection.DeleteOneAsync(filterDefinition);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error while deleting entity.", ex);
        }
    }

    public async Task DeleteManyAsync(Func<FilterDefinitionBuilder<T>, FilterDefinition<T>> filter)
    {
        try
        {
            FilterDefinition<T> filterDefinition;
            if (filter == null)
            {
                filterDefinition = Builders<T>.Filter.Empty;
            }
            else
            {
                filterDefinition = filter(Builders<T>.Filter);
            }
            await _collection.DeleteManyAsync(filterDefinition);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Error while deleting entities.", ex);
        }
    }
}
