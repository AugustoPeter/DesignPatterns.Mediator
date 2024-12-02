namespace DesignPatterns.Mediator.Domain.DomainObjects;


public abstract class Entity<T>(T id) : EntityBase, IAggregateRoot
{
    public virtual T Id { get; } = id;

    public override bool Equals(object? obj)
    {
        var compareTo = obj as Entity<T>;

        if (ReferenceEquals(this, compareTo)) return true;
        return !ReferenceEquals(null, compareTo) && Id.Equals(compareTo.Id);
    }

    public static bool operator ==(Entity<T> a, Entity<T> b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity<T> a, Entity<T> b)
    {
        return !(a == b);
    }


    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }

}

public abstract class EntityBase
{
}
