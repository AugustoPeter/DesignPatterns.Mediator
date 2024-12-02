using MediatR;
using System.Windows.Input;

namespace DesignPatterns.Mediator.Application.Communication;

/// <summary>
///     <inheritdoc cref="ICommandHandler{TCommand}" />
/// </summary>
/// <typeparam name="TCommand">
///     <inheritdoc cref="ICommandHandler{TCommand}" path="/typeparam" />
/// </typeparam>
/// <typeparam name="TResult">Type of the object, that will be returned as command execution result.</typeparam>
public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
    where TCommand : ICommand<TResult>;