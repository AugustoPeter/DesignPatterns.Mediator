using DesignPatterns.Mediator.Domain.DomainObjects;

namespace DesignPatterns.Mediator.Data.Shared;

public interface IBaseRepository<T> : IRepository<T> where T : class, IAggregateRoot
{
}
