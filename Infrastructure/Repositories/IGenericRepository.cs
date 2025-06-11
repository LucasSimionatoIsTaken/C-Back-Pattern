using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public interface IGenericRepository<T>
{
    Task AddAsync(T entity, CancellationToken cancellationToken);

    Task<(List<T> data, int total)> ListAllAsync(
        Expression<Func<T, bool>>? filters = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int page = 1,
        int pageSize = 10,
        bool noTrack = true,
        CancellationToken ct = default,
        params Expression<Func<T, object>>[] includes
    );
    
    void Update(T entity, CancellationToken cancellationToken);
    
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}