using AutoMapper;
using DesignPatterns.Mediator.Data.Context;
using DesignPatterns.Mediator.Data.Repository.Shared.BaseRepository;
using DesignPatterns.Mediator.Data.Repository.Shared.Command;
using DesignPatterns.Mediator.Data.Repository.Shared.Query;
using DesignPatterns.Mediator.Domain.DomainObjects;
using Microsoft.Extensions.Configuration;

namespace DesignPatterns.Mediator.Data.Repository.Operations;

public sealed class OperationCommandRepository<T>(OperationContext context) : CommandRepository<T>(context), IOperationCommandRepository<T> where T : class, IAggregateRoot;
public sealed class OperationQueryRepository<T>(OperationContext context, IMapper mapper) : QueryRepository<T>(context, mapper), IOperationQueryRepository<T> where T : class, IAggregateRoot;
public sealed class OperationRepository<T>(OperationContext context, IConfiguration configuration, IMapper mapper)
    : BaseRepository<T>(context, configuration, mapper), IOperationRepository<T> where T : class, IAggregateRoot;
