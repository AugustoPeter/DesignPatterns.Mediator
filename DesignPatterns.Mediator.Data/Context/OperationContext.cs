using Microsoft.EntityFrameworkCore;

namespace DesignPatterns.Mediator.Data.Context;

public class OperationContext : DbContext
{
    public OperationContext(DbContextOptions<OperationContext> option) : base(option) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(OperationContext).Assembly);
        CustomConfigure(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    #region [ Configurations ]

    private static void CustomConfigure(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            foreach (var mutableProperty in entityType.GetProperties())
            {
                if (mutableProperty.ClrType != typeof(decimal))
                    continue;

                mutableProperty.SetPrecision(9);
                mutableProperty.SetScale(2);
            }
    }


    #endregion

}
