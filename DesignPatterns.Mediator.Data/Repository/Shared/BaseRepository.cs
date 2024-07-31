using AutoMapper;
using DesignPatterns.Mediator.Data.Repository.Shared.Command;
using DesignPatterns.Mediator.Data.Repository.Shared.Query;
using DesignPatterns.Mediator.Data.Shared;
using DesignPatterns.Mediator.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Mediator.Data.Repository.Shared;

public class BaseRepository<T>(DbContext context, IConfiguration configuration, IMapper mapper)
    : Repository<T>(new CommandRepository<T>(context),
                    new QueryRepository<T>(context, mapper),
                    new DapperRepository<T>(configuration)),
    IBaseRepository<T>
    where T : class, IAggregateRoot;
