using Microsoft.AspNetCore.Mvc;

namespace Product.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductBaseController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
