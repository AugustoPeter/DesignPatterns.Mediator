using DesignPatterns.Mediator.Domain.DomainObjects;
using System.Linq.Expressions;

namespace DesignPatterns.Mediator.Data.Repository.Shared.Query;

public interface IQueryRepository<T> : IDisposable where T : IAggregateRoot
{
    IQueryable<T> Queryable { get; }

    bool Any();

    bool Any(Expression<Func<T, bool>> where);

    Task<bool> AnyAsync(CancellationToken cancellationToken);

    Task<bool> AnyAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default);

    long Count();

    long Count(Expression<Func<T, bool>> where);

    Task<long> CountAsync(CancellationToken cancellationToken = default);

    Task<long> CountAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default);

    T Get(object key);

    Task<T> GetAsync(object key, CancellationToken cancellationToken = default);

    IReadOnlyList<T> List();

    Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<T>> ListAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<T2>> ListAsync<T2>(CancellationToken cancellationToken);

    Task<IReadOnlyList<T2>> ListAsync<T2>(Expression<Func<T, bool>> where, CancellationToken cancellationToken);
    Task<T2> GetAsync<T2>(object key, CancellationToken cancellationToken);
    Task<T?> GetAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken);
}
