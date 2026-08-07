using MediatR;

namespace Ordering.Domain.Abstractions;

/// <summary>
/// An event is something that has happened in the past.
/// A domain event is, something that happened in the domain
/// that you want other parts of the same domain (in-process) 
///  to be aware of. The notified parts usually react somehow to the events.
/// 
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
