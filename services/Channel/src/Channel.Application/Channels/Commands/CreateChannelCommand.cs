using Channel.Domain.Channels;
using MediatR;

namespace Channel.Application.Channels.Commands;

public class CreateChannelCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Visibility Visibility { get; set; }
}