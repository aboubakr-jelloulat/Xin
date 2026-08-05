namespace Ordering.Domain.Abstractions;

/// <summary>
/// Represents an aggregate root in Domain-Driven Design that can raise domain events.
/// </summary>
public interface IAggregate : IEntity
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }

    IDomainEvent[] ClearDomainEvents();
}

/// <summary>
/// Represents an aggregate root with a specific type for its identifier.
/// </summary>
/// <typeparam name="T">The type of the aggregate's identifier (e.g., Guid, int).</typeparam>
public interface IAggregate<T> : IAggregate, IEntity<T>
{

}
