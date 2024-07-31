using DesignPatterns.Mediator.Data.Repository.Shared.Command;
using DesignPatterns.Mediator.Data.Repository.Shared.Query;
using DesignPatterns.Mediator.Data.Shared;
using DesignPatterns.Mediator.Domain.DomainObjects;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Mediator.Data.Repository.Shared;

public abstract class Repository<T> : IRepository<T> where T : IAggregateRoot
{
    private readonly ICommandRepository<T> _commandRepository;
    private readonly IDapperRepository<T> _dapperRepository;
    private readonly IQueryRepository<T> _queryRepository;


    protected Repository(
        ICommandRepository<T> commandRepository,
        IQueryRepository<T> queryRepository,
        IDapperRepository<T> dapperRepository
    )
    {
        _commandRepository = commandRepository;
        _queryRepository = queryRepository;
        _dapperRepository = dapperRepository;
    }

    public IQueryable<T> Queryable => _queryRepository.Queryable;

    public DbContext Context => _commandRepository.Context;

    public void Add(T item)
    {
        _commandRepository.Add(item);
    }

    public async Task AddAsync(T item, CancellationToken cancellationToken)
    {
        await _commandRepository.AddAsync(item, cancellationToken);
    }

    public void AddRange(IEnumerable<T> items)
    {
        _commandRepository.AddRange(items);
    }

    public async Task AddRangeAsync(IEnumerable<T> items, CancellationToken cancellationToken)
    {
        await _commandRepository.AddRangeAsync(items, cancellationToken);
    }

    public void BulkInsert(IEnumerable<T> items)
    {
        _commandRepository.BulkInsert(items);
    }

    public async Task BulkInsertAsync(IEnumerable<T> items, CancellationToken cancellationToken)
    {
        await _commandRepository.BulkInsertAsync(items, cancellationToken);
    }

    public bool Any()
    {
        return _queryRepository.Any();
    }

    public bool Any(Expression<Func<T, bool>> where)
    {
        return _queryRepository.Any(where);
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken)
    {
        return await _queryRepository.AnyAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken)
    {
        return await _queryRepository.AnyAsync(where, cancellationToken);
    }

    public long Count()
    {
        return _queryRepository.Count();
    }

    public long Count(Expression<Func<T, bool>> where)
    {
        return _queryRepository.Count(where);
    }

    public async Task<long> CountAsync(CancellationToken cancellationToken)
    {
        return await _queryRepository.CountAsync(cancellationToken);
    }

    public async Task<long> CountAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken)
    {
        return await _queryRepository.CountAsync(where, cancellationToken);
    }

    public void Delete(object key)
    {
        _commandRepository.Delete(key);
    }

    public void Delete(Expression<Func<T, bool>> where)
    {
        _commandRepository.Delete(where);
    }

    public async Task DeleteAsync(object key, CancellationToken cancellationToken)
    {
        await _commandRepository.DeleteAsync(key, cancellationToken);
    }

    public async Task DeleteAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken)
    {
        await _commandRepository.DeleteAsync(where, cancellationToken);
    }

    public T Get(object key)
    {
        return _queryRepository.Get(key);
    }

    public async Task<T> GetAsync(object key, CancellationToken cancellationToken)
    {
        return await _queryRepository.GetAsync(key, cancellationToken);
    }

    public IReadOnlyList<T> List()
    {
        return _queryRepository.List();
    }

    public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken)
    {
        return await _queryRepository.ListAsync(where, cancellationToken);
    }

    public async Task<IReadOnlyList<T>> ListAsync(CancellationToken cancellationToken)
    {
        return await _queryRepository.ListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T2>> ListAsync<T2>(CancellationToken cancellationToken)
    {
        return await _queryRepository.ListAsync<T2>(cancellationToken);
    }

    public async Task<IReadOnlyList<T2>> ListAsync<T2>(Expression<Func<T, bool>> where, CancellationToken cancellationToken)
    {
        return await _queryRepository.ListAsync<T2>(where,
            cancellationToken);
    }

    public async Task<T2> GetAsync<T2>(object key, CancellationToken cancellationToken)
    {
        return await _queryRepository.GetAsync<T2>(key, cancellationToken);
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken)
    {
        return await _queryRepository.GetAsync(where, cancellationToken);
    }

    public void Update(T item)
    {
        _commandRepository.Update(item);
    }

    public async Task UpdateAsync(T item, CancellationToken cancellationToken)
    {
        await _commandRepository.UpdateAsync(item, cancellationToken);
    }

    public void UpdatePartial(object item)
    {
        _commandRepository.UpdatePartial(item);
    }

    public async Task UpdatePartialAsync(object item, CancellationToken cancellationToken)
    {
        await _commandRepository.UpdatePartialAsync(item, cancellationToken);
    }

    public void UpdateRange(IEnumerable<T> items)
    {
        _commandRepository.UpdateRange(items);
    }

    public async Task UpdateRangeAsync(IEnumerable<T> items, CancellationToken cancellationToken)
    {
        await _commandRepository.BulkUpdateAsync(items, cancellationToken);
    }

    public async Task BulkSaveChangesAsync(CancellationToken cancellationToken)
    {
        await _commandRepository.BulkSaveChangesAsync(cancellationToken);
    }

    public async Task BulkUpdateAsync(IEnumerable<T> items, CancellationToken cancellationToken, BulkConfig? bulkConfig = null)
    {
        await _commandRepository.BulkUpdateAsync(items, cancellationToken);
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
        _commandRepository.Dispose();
        _queryRepository.Dispose();
        _dapperRepository.Dispose();
    }

    public async Task<IList<T>> QueryAsync(string sql, CancellationToken cancellationToken = default)
    {
        return await _dapperRepository.QueryAsync(sql, cancellationToken);
    }

    public async Task<IList<T2>> QueryAsync<T2>(string sql, CancellationToken cancellationToken = default)
    {
        return await _dapperRepository.QueryAsync<T2>(sql, cancellationToken);
    }

    public async Task<T> ExecuteScalarAsync(string sql,CancellationToken cancellationToken = default)
    {
        return await _dapperRepository.ExecuteScalarAsync(sql, cancellationToken);
    }

    public async Task<T2> ExecuteScalarAsync<T2>(string sql, CancellationToken cancellationToken = default)
    {
        return await _dapperRepository.ExecuteScalarAsync<T2>(sql, cancellationToken);
    }

    public async Task<int> ExecuteAsync(string sql, CancellationToken cancellationToken = default)
    {
        return await _dapperRepository.ExecuteAsync(sql, cancellationToken);
    }
}
