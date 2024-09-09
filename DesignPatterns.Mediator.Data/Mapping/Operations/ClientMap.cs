using DesignPatterns.Mediator.Domain.Operations.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesignPatterns.Mediator.Data.Mapping.Operations;

public class ClientMap : IEntityTypeConfiguration<ClientEntity>
{
    public void Configure(EntityTypeBuilder<ClientEntity> builder)
    {
        builder.ToTable("clients");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name);
        builder.Property(x => x.Document);
        builder.Property(x => x.Bank);

    }
}
