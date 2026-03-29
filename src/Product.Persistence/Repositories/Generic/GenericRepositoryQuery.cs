using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Contracts.Repositories;
using Product.Persistence.Configurations.SqlServer;

namespace Product.Persistence.Repositories.Generic;

internal class GenericRepositoryQuery(DataContext dataContext) : IGenericRepositoryQuery
{
    public IQueryable<T> Query<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
    {
        var query = dataContext.Set<T>()
            .AsQueryable();

        query = includeProperties.Aggregate(query, (current, includeProperty)
            => current.Include(includeProperty));

        return query;
    }

    public IQueryable<T> QueryAsNoTracking<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
    {
        var query = dataContext.Set<T>().AsQueryable().AsNoTrackingWithIdentityResolution();

        if (includeProperties != null)
        {
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        return query;
    }

    public IQueryable<T> QueryIncludeStringProperties<T>(params string[] includeProperties) where T : class
    {
        var query = dataContext.Set<T>().AsQueryable();
        if (includeProperties is { Length: > 0 })
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

        return query;
    }
}