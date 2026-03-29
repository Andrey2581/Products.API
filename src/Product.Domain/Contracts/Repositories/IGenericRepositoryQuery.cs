using System.Linq.Expressions;

namespace Product.Domain.Contracts.Repositories;

public interface IGenericRepositoryQuery
{
    IQueryable<T> Query<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;

    IQueryable<T> QueryAsNoTracking<T>(params Expression<Func<T, object>>[] includeProperties) where T : class;

    IQueryable<T> QueryIncludeStringProperties<T>(params string[] includeProperties) where T : class;
}