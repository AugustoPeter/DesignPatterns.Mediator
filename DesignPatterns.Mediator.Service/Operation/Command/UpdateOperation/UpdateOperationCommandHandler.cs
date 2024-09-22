using DesignPatterns.Mediator.Application.Communication;
using DesignPatterns.Mediator.Data.Repository.Operations;
using DesignPatterns.Mediator.Domain.Operations.Entities;

namespace DesignPatterns.Mediator.Application.Operation.Command.UpdateOperation;

public sealed class UpdateOperationCommandHandler
    (IOperationCommandRepository<OperationEntity> _commandRepository, IOperationQueryRepository<OperationEntity> _queryRepository)
    : ICommandHandler<UpdateOperationCommand, bool>
{
    public async Task<bool> Handle(UpdateOperationCommand request, CancellationToken cancellationToken)
    {
        var operation = await _queryRepository.GetAsync(request.Id, cancellationToken);

        operation.UpdateValues(request.Asset, request.AssetCode, request.Institution, request.Value, request.Quantity);

        await _commandRepository.UpdateAsync(operation);
        
        return await Task.FromResult(true);
    }
}