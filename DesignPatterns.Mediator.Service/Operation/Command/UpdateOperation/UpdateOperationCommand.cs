using DesignPatterns.Mediator.Application.Communication;
using FluentValidation;

namespace DesignPatterns.Mediator.Application.Operation.Command.UpdateOperation;

public sealed record UpdateOperationCommand(Guid Id, string Asset, string AssetCode, string Institution, decimal Value, int Quantity)
 : ICommand<bool>;


public sealed class UpdateOperationCommandValidator : AbstractValidator<UpdateOperationCommand>
{
    public UpdateOperationCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id do registro deve ser informado");
    }
}