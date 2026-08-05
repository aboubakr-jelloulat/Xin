namespace Ordering.Domain.Abstractions;

public interface IEntity
{
    public DateTime? CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }

}

/// <summary>
///  adds the Id but it's generic (T) because not every entity's ID is the same type
/// </summary>
/// <typeparam name="T"></typeparam>


public interface IEntity<T> : IEntity
{
    public T Id { get; set; }
}
