using DesignPatterns.Mediator.Data.Repository.Shared.Extensions;
using DesignPatterns.Mediator.Domain.DomainObjects;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DesignPatterns.Mediator.Data.Repository.Shared.Command;

public class CommandRepository<T>(DbContext context) : ICommandRepository<T>
    where T : class, IAggregateRoot
{
    public DbContext Context => context;
    private DbSet<T> Set => context.CommandSet<T>();

    public void Add(T item) => Set.Add(item);

    public async Task AddAsync(T item, CancellationToken cancellationToken) => await Set.AddAsync(item, cancellationToken).AsTask();

    public void AddRange(IEnumerable<T> items) => Set.AddRange(items);

    public async Task AddRangeAsync(IEnumerable<T> items, CancellationToken cancellationToken) => await context.AddRangeAsync(items, cancellationToken: cancellationToken);

    public void BulkInsert(IEnumerable<T> items) => context.BulkInsert(items);

    public async Task BulkInsertAsync(IEnumerable<T> items, CancellationToken cancellationToken)
    {
        var bulkConfig = new BulkConfig { BatchSize = 4000 };
        await context.BulkInsertAsync(items, bulkConfig, cancellationToken: cancellationToken);
    }

    public void Delete(object key)
    {
        var item = Set.Find(key);

        if (item is null) return;

        Set.Remove(item);
    }

    public void Delete(Expression<Func<T, bool>> where)
    {
        var items = Set.Where(where);

        if (!items.Any()) return;

        context.BulkDelete(items);
    }

    public Task DeleteAsync(object key, CancellationToken cancellationToken)
    {
        return Task.Run(() => Delete(key), cancellationToken);
    }

    public Task DeleteAsync(Expression<Func<T, bool>> where, CancellationToken cancellationToken)
    {
        var items = Set.Where(where);

        return items.BatchDeleteAsync(cancellationToken);
    }

    public void Update(T item)
    {
        var primaryKeyValues = context.PrimaryKeyValues<T>(item);

        var entity = Set.Find(primaryKeyValues);

        if (entity is null) return;

        context.Entry(entity).State = EntityState.Detached;

        context.Update(item);
    }

    public Task UpdateAsync(T item, CancellationToken cancellationToken)
    {
        return Task.Run(() => Update(item), cancellationToken);
    }

    public void UpdatePartial(object item)
    {
        var primaryKeyValues = context.PrimaryKeyValues<T>(item);

        var entity = Set.Find(primaryKeyValues);

        if (entity is null) return;

        var entry = context.Entry(entity);

        entry.CurrentValues.SetValues(item);

        foreach (var navigation in entry.Metadata.GetNavigations())
        {
            if (navigation.IsOnDependent || navigation.IsCollection || !navigation.ForeignKey.IsOwnership) continue;

            var property = item.GetType().GetProperty(navigation.Name);

            if (property is null) continue;

            var value = property.GetValue(item, default);

            entry.Reference(navigation.Name).TargetEntry?.CurrentValues.SetValues(value!);
        }
    }

    public Task UpdatePartialAsync(object item, CancellationToken cancellationToken)
    {
        return Task.Run(() => UpdatePartial(item), cancellationToken);
    }

    public void UpdateRange(IEnumerable<T> items)
    {
        Set.UpdateRange(items);
    }

    public async Task UpdateRangeAsync(IEnumerable<T> items, CancellationToken cancellationToken)
    {
        var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var config = new BulkConfig()
        {
            UseTempDB = true,
            BatchSize = 4000,
            CalculateStats = true
        };
        await context.BulkUpdateAsync(items, cancellationToken: cancellationToken, bulkConfig: config);

        await transaction.CommitAsync(cancellationToken);
    }


    public async Task BulkSaveChangesAsync(CancellationToken cancellationToken)
    {
        var bulkConfig = new BulkConfig { BatchSize = 4000 };
        await context.BulkSaveChangesAsync(bulkConfig, cancellationToken: cancellationToken); ;
    }

    /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
    public void Dispose()
    {
        context.Dispose();
    }

    public async Task BulkUpdateAsync(IEnumerable<T> items, CancellationToken cancellationToken, BulkConfig? bulkConfig = null)
    {
        var transaction = await context.Database.BeginTransactionAsync(cancellationToken);

        var config = new BulkConfig()
        {
            UseTempDB = true,
            BatchSize = 4000,
            CalculateStats = true
        };

        if (bulkConfig != null)
            config = bulkConfig;

        await context.BulkUpdateAsync(items, cancellationToken: cancellationToken, bulkConfig: config);

        await transaction.CommitAsync(cancellationToken);
    }
}
