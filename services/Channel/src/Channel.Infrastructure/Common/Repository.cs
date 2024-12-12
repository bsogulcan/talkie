using Channel.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Channel.Infrastructure.Common;

public class Repository<TDbContext, TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : Entity<TKey>
    where TDbContext : DbContext
{
    private readonly TDbContext _dbContext;

    public Repository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var result = await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return result.Entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var dbSet = _dbContext.Set<TEntity>();
        var existingEntity = await dbSet.FindAsync(new object[] { entity.Id }, cancellationToken);
        if (existingEntity == null)
        {
            throw new KeyNotFoundException($"Entity with ID {entity.Id} not found.");
        }

        _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return existingEntity;
    }

    public async Task DeleteAsync(TEntity id, CancellationToken cancellationToken = default)
    {
        var dbSet = _dbContext.Set<TEntity>();
        var entity = await dbSet.FindAsync([id], cancellationToken);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Entity with ID {id} not found.");
        }

        dbSet.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        var dbSet = _dbContext.Set<TEntity>();
        var entity = await dbSet.FindAsync([id], cancellationToken);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Entity with ID {id} not found.");
        }

        return entity;
    }

    public Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}