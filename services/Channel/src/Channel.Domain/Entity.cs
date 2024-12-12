using System.Data.Common;

namespace Channel.Domain;

public class Entity<T>
{
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public bool IsDeleted { get; set; }

    public Entity(T id)
    {
        Id = id;
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }
}