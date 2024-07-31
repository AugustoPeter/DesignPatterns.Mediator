using DesignPatterns.Mediator.Domain.DomainObjects;

namespace DesignPatterns.Mediator.Data.Shared;

public interface IDapperRepository<T> : IDisposable where T : IAggregateRoot
{
    public Task<IList<T>> QueryAsync(string sql, CancellationToken cancellationToken = default);
    public Task<IList<T2>> QueryAsync<T2>(string sql, CancellationToken cancellationToken = default);
    public Task<T> ExecuteScalarAsync(string sql, CancellationToken cancellationToken = default);
    Task<T2> ExecuteScalarAsync<T2>(string sql,  CancellationToken cancellationToken = default);
    public Task<int> ExecuteAsync(string sql, CancellationToken cancellationToken = default);
}
