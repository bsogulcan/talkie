namespace Channel.Domain.Channels;

public class Channel : Entity<Guid>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Visibility Visibility { get; set; }
    public List<UserWithRole> Members { get; set; }

    public Channel(Guid id, string name, string description, Visibility visibility) : base(id)
    {
        Name = name;
        Description = description;
        Visibility = visibility;
        Members = [];
    }
}