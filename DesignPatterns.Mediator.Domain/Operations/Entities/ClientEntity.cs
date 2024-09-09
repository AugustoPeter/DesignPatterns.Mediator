﻿using DesignPatterns.Mediator.Domain.DomainObjects;

namespace DesignPatterns.Mediator.Domain.Operations.Entities;

public class ClientEntity : Entity<Guid>
{

    public ClientEntity() : base(default) { }
    public ClientEntity(Guid id) : base(id) { }

    public ClientEntity(Guid id, string name, string document, string bank) : base(id)
    {
        Name = name;
        Document = document;
        Bank = bank;
    }

    public string Name { get; set; }
    public string Document { get; set; }
    public string Bank { get; set; }


}