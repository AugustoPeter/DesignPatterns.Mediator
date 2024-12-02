using DesignPatterns.Mediator.Application.Communication;
using DesignPatterns.Mediator.Data.Repository.Operations;
using DesignPatterns.Mediator.Domain.Operations.Entities;

namespace DesignPatterns.Mediator.Application.Operation.Query.GetClientOperation;

public class GetClientOperationQueryHandler
    (IOperationQueryRepository<OperationEntity> _queryRepository)
    : IQueryHandler<GetClientOperationQuery, IEnumerable<GetClientOperationQueryResponse>>
{
    public async Task<IEnumerable<GetClientOperationQueryResponse>> Handle(GetClientOperationQuery request, CancellationToken cancellationToken)
    {
        var clientOperations = await _queryRepository.ListAsync(x => x.ClientId == request.clientId, cancellationToken);

        return clientOperations.Select(x => new GetClientOperationQueryResponse(x.Asset, x.Institution, x.Value, x.Quantity, x.OperationDate));
    }
}
