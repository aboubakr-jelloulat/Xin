namespace Ordering.Domain.Abstractions;

/// <summary>
/// Defines the common auditing information that every domain entity should expose,
/// including creation and modification metadata.
/// </summary>
public interface IEntity
{
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }

}

/// <summary>
/// Defines a domain entity with a strongly typed identifier.
/// </summary>
/// <typeparam name="T">
/// The type of the entity identifier.
/// </typeparam>

public interface IEntity<T> : IEntity
{
    public T Id { get; set; }
}
