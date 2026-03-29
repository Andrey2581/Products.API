using System.Linq.Expressions;
using Product.Domain.SeedWorks;

namespace Product.Domain.Contracts.Repositories;

public interface IRepository<T> : IUnitOfWork where T : class, IAggregateRoot
{
    Task<List<T>> GetAllAsync();

    Task<T> GetByIdAsync(int id);

    Task<T> GetByCriteriaAsync(Expression<Func<T, bool>> criteria);

    Task<List<T>> GetListByCriteriaAsync(Expression<Func<T, bool>> criteria);

    Task AddAsync(T entity);

    Task AddRangeAsync(IEnumerable<T> entities);

    void Remove(T item);

    void RemoveRange(IEnumerable<T> entities);

    void Update(T entity);

    void UpdateRange(IEnumerable<T> entities);

    Task BeginTransaction();

    void RollbackTransaction();

    void CommitTransaction();
}