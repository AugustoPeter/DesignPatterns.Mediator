using DesignPatterns.Mediator.Data.Repository.Shared.Command;
using DesignPatterns.Mediator.Data.Repository.Shared.Dapper;
using DesignPatterns.Mediator.Data.Repository.Shared.Query;
using DesignPatterns.Mediator.Domain.DomainObjects;

namespace DesignPatterns.Mediator.Data.Repository.Shared.GenericRepository;

public interface IRepository<T> : ICommandRepository<T>, IQueryRepository<T>, IDapperRepository<T> where T : IAggregateRoot
{
}
