using Channel.Application.Channels.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Channel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChannelController : ControllerBase
{
    private readonly IMediator _mediator;

    public ChannelController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("secure-data")]
    [Authorize]
    public IActionResult GetSecureData()
    {
        return Ok(new
            { Message = "Bu verilere yalnızca yetkili kullanıcılar erişebilir! Name=" + User.Identity?.Name });
    }

    [HttpGet("data")]
    public IActionResult GetData()
    {
        return Ok(new { Message = "Public!" });
    }

    [HttpPost]
    public async Task<IActionResult> CreateChannelAsync([FromBody] CreateChannelCommand command)
    {
        var channelId = await _mediator.Send(command);
        return Ok(channelId);
    }
}