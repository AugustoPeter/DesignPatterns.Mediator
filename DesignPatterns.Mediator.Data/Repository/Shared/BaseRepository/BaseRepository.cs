using AutoMapper;
using DesignPatterns.Mediator.Data.Repository.Shared.Command;
using DesignPatterns.Mediator.Data.Repository.Shared.Dapper;
using DesignPatterns.Mediator.Data.Repository.Shared.GenericRepository;
using DesignPatterns.Mediator.Data.Repository.Shared.Query;
using DesignPatterns.Mediator.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DesignPatterns.Mediator.Data.Repository.Shared.BaseRepository;

public class BaseRepository<T>(DbContext context, IConfiguration configuration, IMapper mapper)
    : Repository<T>(new CommandRepository<T>(context),
                    new QueryRepository<T>(context, mapper),
                    new DapperRepository<T>(configuration)),
    IBaseRepository<T>
    where T : class, IAggregateRoot;
