using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Channel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChannelController : ControllerBase
{
    [HttpGet("secure-data")]
    [Authorize]
    public IActionResult GetSecureData()
    {
        return Ok(new { Message = "Bu verilere yalnızca yetkili kullanıcılar erişebilir! Name=" + User.Identity?.Name });
    }

    [HttpGet("data")]
    public IActionResult GetData()
    {
        return Ok(new { Message = "Public!" });
    }
}