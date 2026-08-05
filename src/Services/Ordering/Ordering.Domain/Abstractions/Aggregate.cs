namespace Ordering.Domain.Abstractions;

/// <summary>
/// Represents an aggregate root in Domain-Driven Design (DDD).
///
/// An aggregate root is the entry point to an aggregate and is responsible
/// for maintaining consistency across all entities within its boundary.
/// It can collect and expose domain events that occurred during business operations.
/// </summary>
/// 

public abstract class Aggregate<TId> : Entity<TId>, IAggregate<TId>
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();


    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public IDomainEvent[] ClearDomainEvents()
    {
        var events = _domainEvents.ToArray();

        _domainEvents.Clear();

        return (events);
    }
}
