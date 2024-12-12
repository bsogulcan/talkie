using Microsoft.EntityFrameworkCore;

namespace Channel.Infrastructure.Data;

public class ChannelDbContext : DbContext
{
    public ChannelDbContext(DbContextOptions<ChannelDbContext> options) : base(options)
    {
    }
}