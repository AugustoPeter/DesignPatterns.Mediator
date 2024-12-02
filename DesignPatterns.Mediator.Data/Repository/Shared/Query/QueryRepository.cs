using AutoMapper;
using AutoMapper.QueryableExtensions;
using DesignPatterns.Mediator.Data.Repository.Shared.Extensions;
using DesignPatterns.Mediator.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DesignPatterns.Mediator.Data.Repository.Shared.Query;

public class QueryRepository<T> : IQueryRepository<T> where T : class, IAggregateRoot
{
    private readonly DbContext _context;
    private readonly IMapper _mapper;

    public QueryRepository(DbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IQueryable<T> Queryable => _context.QuerySet<T>();

    public bool Any()
    {
        return Queryable.Any();
    }

    public bool Any(Expression<Func<T, bool>> where)
    {
        return Queryable.Any(where);
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken)
    {
        return await Queryable.AnyAsync(cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken)
    {
        return await Queryable.AnyAsync(where, cancellationToken);
    }

    public long Count()
    {
        return Queryable.LongCount();
    }

    public long Count(Expression<Func<T, bool>> where)
    {
        return Queryable.LongCount(where);
    }

    public async Task<long> CountAsync(CancellationToken cancellationToken)
    {
        return await Queryable.LongCountAsync(cancellationToken);
    }

    public async Task<long> CountAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken)
    {
        return await Queryable.LongCountAsync(where, cancellationToken);
    }

    public T Get(object key)
    {
        return _context.DetectChangesLazyLoading(false).Set<T>().Find(key)!;
    }

    public async Task<T> GetAsync(object key, CancellationToken cancellationToken)
    {
        return (await _context.DetectChangesLazyLoading(false).Set<T>().FindAsync([key, cancellationToken], cancellationToken).AsTask()!)!;
    }

    public async Task<T2> GetAsync<T2>(object key, CancellationToken cancellationToken)
    {
        var entity = await GetAsync(key, cancellationToken);
        return _mapper.Map<T2>(entity);
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken)
    {
        return await Queryable.FirstOrDefaultAsync(where, cancellationToken);
    }


    public IReadOnlyList<T> List()
    {
        return Queryable.AsNoTracking().ToList();
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken = default)
    {
        return await Queryable.AsNoTracking().Where(where).ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> ListAsync(CancellationToken cancellationToken)
    {
        return await Queryable.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T2>> ListAsync<T2>(CancellationToken cancellationToken)
    {
        return await Queryable.AsNoTracking().ProjectTo<T2>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T2>> ListAsync<T2>(Expression<Func<T, bool>> where, CancellationToken cancellationToken)
    {
        return await Queryable.AsNoTracking().Where(where).ProjectTo<T2>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
    }
}
