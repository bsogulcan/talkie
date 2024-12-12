namespace Channel.Domain.Common;

public interface IRepository;

public interface IBasicRepository<TEntity> : IRepository where TEntity : class, IEntity
{
    Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity id, CancellationToken cancellationToken = default);
}

public interface IRepository<TEntity, TKey> : IBasicRepository<TEntity>
    where TEntity : class, IEntity<TKey>
{
    Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
}