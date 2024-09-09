using DesignPatterns.Mediator.Data.Repository.Shared.BaseRepository;
using DesignPatterns.Mediator.Data.Repository.Shared.Command;
using DesignPatterns.Mediator.Data.Repository.Shared.Query;
using DesignPatterns.Mediator.Domain.DomainObjects;

namespace DesignPatterns.Mediator.Data.Repository.Operations;

/// <summary>
/// Represents a command repository for the Operation entity.
/// </summary>
/// <remarks>For Commands and Queries use the specific repository</remarks>
/// <typeparam name="T">The type of entity.</typeparam>
public interface IOperationRepository<T> : IBaseRepository<T> where T : class, IAggregateRoot;

/// <summary>
/// Represents a command repository for the Operation entity.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
public interface IOperationCommandRepository<T> : ICommandRepository<T> where T : class, IAggregateRoot;

/// <summary>
/// Represents a query repository for the Operation entity.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
public interface IOperationQueryRepository<T> : IQueryRepository<T> where T : class, IAggregateRoot;