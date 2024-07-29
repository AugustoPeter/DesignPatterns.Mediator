using DesignPatterns.Mediator.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Mediator.Domain.Operations.Eneities;

public class Client : Entity<Guid>
{

    public Client() : base(default) { }
    public Client(Guid id) : base(id) { }

    public Client(Guid id, string name, string document, string bank) : base(id)
    {
        Name = name;
        Document = document;
        Bank = bank;
    }

    public string Name { get; set; }
    public string Document { get; set; }
    public string Bank { get; set; }


    public IEnumerable<Operation> Operations { get; set; }


}
