using DesignPatterns.Mediator.Application.Communication;
using DesignPatterns.Mediator.Data.Repository.Operations;
using DesignPatterns.Mediator.Domain.Operations.Entities;

namespace DesignPatterns.Mediator.Application.Operation.Command.AddOperation;

public sealed class AddOperationCommandHandler
    (IOperationCommandRepository<OperationEntity> _commandRepository)
    : ICommandHandler<AddOperationCommand, bool>
{
    public async Task<bool> Handle(AddOperationCommand request, CancellationToken cancellationToken)
    {
        var operation = new OperationEntity(request.Asset, request.AssetCode, request.Institution, request.Value, request.Quantity);
        
        await _commandRepository.AddAsync(operation);

        return await Task.FromResult(true);
    }
}