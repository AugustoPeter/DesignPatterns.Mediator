using DesignPatterns.Mediator.Application.Communication;
using FluentValidation;

namespace DesignPatterns.Mediator.Application.Operation.Query.GetClientOperation;

public record GetClientOperationQuery(Guid clientId) 
    : IQuery<IEnumerable<GetClientOperationQueryResponse>>;
public record GetClientOperationQueryResponse(string Asset, string Institution, decimal Value, int Quantity, DateTime Date);


#region
public class GetClientOperationQueryValidation : AbstractValidator<GetClientOperationQuery>
{
    public GetClientOperationQueryValidation()
    {
        RuleFor(x => x.clientId).NotEmpty().NotNull().WithMessage("Id do cliente deve ser informado");
    }
}

#endregion