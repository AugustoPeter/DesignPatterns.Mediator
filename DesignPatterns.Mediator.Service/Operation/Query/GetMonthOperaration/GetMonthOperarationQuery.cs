using DesignPatterns.Mediator.Application.Communication;

namespace DesignPatterns.Mediator.Application.Operation.Query.GetMonthOperaration;

public record GetMonthOperarationQuery()
    : IQuery<IEnumerable<GetMonthOperarationQueryResponse>>;
public record GetMonthOperarationQueryResponse(string Asset, string Institution, decimal Value, int Quantity, DateTime Date, string ClientName, string Bank);

