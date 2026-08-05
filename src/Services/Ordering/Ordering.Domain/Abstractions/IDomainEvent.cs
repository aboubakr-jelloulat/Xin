using MediatR;

namespace Ordering.Domain.Abstractions;

/// <summary>
/// Represents a domain event that describes something significant
/// that has already occurred within the domain.
///
/// Domain events are used to notify other parts of the same domain
/// so they can react to business changes without creating tight coupling.
///
/// Every domain event provides:
/// - A unique event identifier.
/// - The date and time when the event occurred.
/// - The event type, which can be useful for logging, auditing,
///   or event persistence.
/// </summary>

public interface IDomainEvent : INotification
{
    Guid EventId => Guid.NewGuid();

    public DateTime OccurredOn => DateTime.Now;

    public string EventType => GetType().AssemblyQualifiedName!;

}
