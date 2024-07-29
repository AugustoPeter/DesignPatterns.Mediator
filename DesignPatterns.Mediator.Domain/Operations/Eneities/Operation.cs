using DesignPatterns.Mediator.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Mediator.Domain.Operations.Eneities;

public class Operation : Entity<Guid>
{
    public Operation() : base(default) { }

    public Operation(Guid id) : base (id) { }

    public string Asset { get; set; }
    public string AssetCode { get; set; }
    public string Institution { get; set; }
    public decimal Value { get; set; }
    public int Quantity { get; set; }

    public Client Client { get; set; }
}
