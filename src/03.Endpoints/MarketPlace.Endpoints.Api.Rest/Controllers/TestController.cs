using Microsoft.AspNetCore.Mvc;

namespace MarketPlace.Endpoints.Api.Rest.Controllers;

[Route("[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpPost]
    public IActionResult Post()
    {
        return Ok("The Kingdom");
    }
}
