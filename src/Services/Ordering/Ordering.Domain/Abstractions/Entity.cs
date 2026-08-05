namespace Ordering.Domain.Abstractions;

/// <summary>
/// Represents the base class for all domain entities.
/// Provides a strongly typed identifier and common auditing properties,
/// such as creation and modification information, that can be shared
/// across all entities in the domain.
/// </summary>
/// <typeparam name="T">
/// The type of the entity identifier (for example, <see cref="Guid"/>, <see cref="int"/>, or <see cref="string"/>).
/// </typeparam>
public class Entity<T> : IEntity<T>
{
    public T Id { get; set ; }
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}
