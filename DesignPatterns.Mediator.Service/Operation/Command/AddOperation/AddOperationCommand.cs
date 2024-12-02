using DesignPatterns.Mediator.Application.Communication;
using FluentValidation;

namespace DesignPatterns.Mediator.Application.Operation.Command.AddOperation;

public sealed record AddOperationCommand(string Asset, string AssetCode, string Institution, decimal Value, int Quantity)
 : ICommand<bool>;


public sealed class AddOperationCommandValidator : AbstractValidator<AddOperationCommand>
{
    public AddOperationCommandValidator()
    {
        RuleFor(x => x.AssetCode).NotEmpty().WithMessage("Ativo deve ser inforamdo ");
        RuleFor(x => x.AssetCode).NotEmpty().WithMessage("Codigo do Ativo deve ser inforamdo ");

    }
}