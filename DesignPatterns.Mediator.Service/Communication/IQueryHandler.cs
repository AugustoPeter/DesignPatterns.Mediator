using MediatR;

namespace DesignPatterns.Mediator.Application.Communication;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{

}
