using DesignPatterns.Mediator.Application.Communication;
using DesignPatterns.Mediator.Application.Operation.Query.GetClientOperation;
using DesignPatterns.Mediator.Data.Repository.Operations;
using DesignPatterns.Mediator.Domain.Operations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Mediator.Application.Operation.Query.GetMonthOperaration;

public class GetMonthOperarationQueryHandler
    (IOperationQueryRepository<OperationEntity> _operationQueryRepository,
    IOperationQueryRepository<ClientEntity> _clientQueryRepository)
    : IQueryHandler<GetMonthOperarationQuery, IEnumerable<GetMonthOperarationQueryResponse>>
{
    public async Task<IEnumerable<GetMonthOperarationQueryResponse>> Handle(GetMonthOperarationQuery request, CancellationToken cancellationToken)
    {
        var baseDate = DateTime.Now;

        var response = new List<GetMonthOperarationQueryResponse>();

        var monthOperation = await _operationQueryRepository.ListAsync(x => x.OperationDate <= baseDate && x.OperationDate >= baseDate.AddDays(baseDate.Day + 1));

        var operationClients = await _clientQueryRepository.ListAsync(x => monthOperation.Select(c => c.ClientId).Contains(x.Id), cancellationToken);

        foreach ( var operationClient in operationClients)
        {
            var clintOperations = monthOperation.Where(x => x.ClientId == operationClient.Id);
            clintOperations.Select(x => new GetMonthOperarationQueryResponse(x.Asset, x.Institution, x.Value, x.Quantity, x.OperationDate, operationClient.Name, operationClient.Bank));
        }

        return response;
    }
}
