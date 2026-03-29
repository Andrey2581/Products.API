using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Contracts.Repositories;
using Product.Domain.SeedWorks;

namespace Product.Persistence.Repositories.Generic;

public class DataRepository<T>(DbContext dbContext) : IRepository<T>
    where T : class, IAggregateRoot
{
    private readonly DbSet<T> _dbSet = dbContext.Set<T>();

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> GetByCriteriaAsync(Expression<Func<T, bool>> criteria)
    {
        return await _dbSet.FirstOrDefaultAsync(criteria);
    }

    public async Task<List<T>> GetListByCriteriaAsync(Expression<Func<T, bool>> criteria)
    {
        return await _dbSet.Where(criteria).ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public void Remove(T item)
    {
        _dbSet.Remove(item);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.SaveChangesAsync(cancellationToken) > 0;
    }

    public async Task BeginTransaction()
    {
        await dbContext.Database.BeginTransactionAsync();
    }

    public void RollbackTransaction()
    {
        dbContext.Database.RollbackTransaction();
    }

    public void CommitTransaction()
    {
        dbContext.Database.CommitTransaction();
    }
}