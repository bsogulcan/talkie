using Channel.Domain.Channels;
using Channel.Infrastructure.Common;
using Channel.Infrastructure.EntityFrameworkCore;

namespace Channel.Infrastructure.Repositories;

public class ChannelRepository : Repository<ChannelDbContext, Domain.Channels.Channel, Guid>, IChannelRepository
{
    public ChannelRepository(ChannelDbContext dbContext) : base(dbContext)
    {
    }
}