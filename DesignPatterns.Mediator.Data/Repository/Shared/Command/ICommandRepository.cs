using DesignPatterns.Mediator.Domain.DomainObjects;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DesignPatterns.Mediator.Data.Repository.Shared.Command;

public interface ICommandRepository<T> : IDisposable where T : IAggregateRoot
{
    DbContext Context { get; }
    void Add(T item);

    Task AddAsync(T item, CancellationToken cancellationToken = default);

    void AddRange(IEnumerable<T> items);

    Task AddRangeAsync(IEnumerable<T> items, CancellationToken cancellationToken = default);

    void BulkInsert(IEnumerable<T> items);

    Task BulkInsertAsync(IEnumerable<T> items, CancellationToken cancellationToken);

    void Delete(object key);

    void Delete(Expression<Func<T, bool>> where);

    Task DeleteAsync(object key, CancellationToken cancellationToken = default);

    Task DeleteAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default);

    void Update(T item);

    Task UpdateAsync(T item, CancellationToken cancellationToken = default);

    void UpdatePartial(object item);

    Task UpdatePartialAsync(object item, CancellationToken cancellationToken = default);

    void UpdateRange(IEnumerable<T> items);

    Task UpdateRangeAsync(IEnumerable<T> items, CancellationToken cancellationToken = default);

    Task BulkSaveChangesAsync(CancellationToken cancellationToken);
    Task BulkUpdateAsync(IEnumerable<T> items, CancellationToken cancellationToken, BulkConfig? bulkConfig = null);
}
