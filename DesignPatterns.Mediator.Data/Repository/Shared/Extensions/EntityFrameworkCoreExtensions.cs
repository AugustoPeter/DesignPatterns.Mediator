using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Mediator.Data.Repository.Shared.Extensions;

public static class EntityFrameworkCoreExtensions
{
    public static DbSet<T> CommandSet<T>(this DbContext context) where T : class => context.DetectChangesLazyLoading(true).Set<T>();

    public static DbContext DetectChangesLazyLoading(this DbContext context, bool enabled)
    {
        context.ChangeTracker.AutoDetectChangesEnabled = enabled;
        context.ChangeTracker.LazyLoadingEnabled = enabled;
        context.ChangeTracker.QueryTrackingBehavior = enabled ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking;

        return context;
    }

    public static IQueryable<T> QuerySet<T>(this DbContext context) where T : class => context.DetectChangesLazyLoading(false).Set<T>().AsNoTracking();

    public static object?[]? PrimaryKeyValues<T>(this DbContext context, object entity)
    {
        return context.Model.FindEntityType(typeof(T))?.FindPrimaryKey()?.Properties
            .Select(property => entity.GetType().GetProperty(property.Name)?.GetValue(entity, default)).ToArray();
    }
}
