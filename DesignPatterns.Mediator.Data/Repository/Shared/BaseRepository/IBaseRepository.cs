using DesignPatterns.Mediator.Data.Repository.Shared.GenericRepository;
using DesignPatterns.Mediator.Domain.DomainObjects;

namespace DesignPatterns.Mediator.Data.Repository.Shared.BaseRepository;

public interface IBaseRepository<T> : IRepository<T> where T : class, IAggregateRoot
{
}
