using Channel.Application.Channels.Commands;
using Channel.Domain.Channels;
using MediatR;

namespace Channel.Application.Channels.Handlers;

public class CreateChannelCommandHandler : IRequestHandler<CreateChannelCommand, Guid>
{
    private readonly IChannelRepository _channelRepository;

    public CreateChannelCommandHandler(IChannelRepository channelRepository)
    {
        _channelRepository = channelRepository;
    }

    public async Task<Guid> Handle(CreateChannelCommand request, CancellationToken cancellationToken)
    {
        var channel =
            new Domain.Channels.Channel(Guid.NewGuid(), request.Name, request.Description, request.Visibility);

        channel = await _channelRepository.InsertAsync(channel, cancellationToken);
        return channel.Id;
    }
}