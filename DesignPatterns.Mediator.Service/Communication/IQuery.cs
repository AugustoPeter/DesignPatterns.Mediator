using MediatR;

namespace DesignPatterns.Mediator.Application.Communication;

public interface IQuery<out TResult> : IRequest<TResult>
{
}
