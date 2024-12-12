namespace Channel.Domain.Channels;

public class UserWithRole
{
    public Guid UserId { get; set; }
    public Role Role { get; set; }

    public UserWithRole(Guid userId, Role role = Role.User)
    {
        UserId = userId;
        Role = role;
    }
}