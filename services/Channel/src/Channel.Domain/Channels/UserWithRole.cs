namespace Channel.Domain.Channels;

public class UserWithRole
{
    public Guid ChannelId { get; set; }
    public Guid UserId { get; set; }
    public Role Role { get; set; }

    public UserWithRole(Guid channelId, Guid userId, Role role = Role.User)
    {
        ChannelId = channelId;
        UserId = userId;
        Role = role;
    }
}