using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AmazingTeamTaskManager.Core.Repositories
{
    public abstract class Repository<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        protected readonly TContext _context;

        protected Repository(TContext context)
        {
            _context = context;
        }

        public async Task AddOneAsync(TEntity entity)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add entity: {ex.Message}", ex);
            }
        }

        public async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get entity: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return await _context.Set<TEntity>().Where(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get entities: {ex.Message}", ex);
            }
        }

        public async Task UpdateOneAsync(Expression<Func<TEntity, bool>> filter, Action<TEntity> updateAction)
        {
            try
            {
                var entity = await GetOneAsync(filter);
                if (entity != null)
                {
                    updateAction(entity);
                    _context.Set<TEntity>().Update(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update entity: {ex.Message}", ex);
            }
        }

        public async Task UpdateManyAsync(Expression<Func<TEntity, bool>> filter, Action<TEntity> updateAction)
        {
            try
            {
                var entities = await GetManyAsync(filter);
                foreach (var entity in entities)
                {
                    updateAction(entity);
                    _context.Set<TEntity>().Update(entity);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update entities: {ex.Message}", ex);
            }
        }

        public async Task DeleteOneAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                var entity = await GetOneAsync(filter);
                if (entity != null)
                {
                    _context.Set<TEntity>().Remove(entity);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete entity: {ex.Message}", ex);
            }
        }

        public async Task DeleteManyAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                var entities = await GetManyAsync(filter);
                _context.Set<TEntity>().RemoveRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete entities: {ex.Message}", ex);
            }
        }
    }
}
