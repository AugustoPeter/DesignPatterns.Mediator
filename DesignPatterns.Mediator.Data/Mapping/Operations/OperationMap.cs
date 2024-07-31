using DesignPatterns.Mediator.Domain.Operations.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignPatterns.Mediator.Data.Mapping.Operations;

public class OperationMap : IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder.ToTable("operations");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Asset);
        builder.Property(x => x.AssetCode);
        builder.Property(x => x.Institution);
        builder.Property(x => x.Value);
        builder.Property(x => x.Quantity);
        builder.Property(x => x.ClientId);



    }
}
