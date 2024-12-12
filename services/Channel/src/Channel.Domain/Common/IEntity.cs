namespace Channel.Domain.Common;

public interface IEntity<T> : IEntity
{
    public T Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public bool IsDeleted { get; set; }
}

public interface IEntity
{
}