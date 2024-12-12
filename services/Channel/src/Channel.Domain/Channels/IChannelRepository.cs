using Channel.Domain.Common;

namespace Channel.Domain.Channels;

public interface IChannelRepository : IRepository<Channel, Guid>
{
}