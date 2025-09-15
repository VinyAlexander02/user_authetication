using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace user_auth.Controller;

[ApiController]
[Route("[controller]")]
public class AcessController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "MinAge")]
    public ActionResult Get()
    {
        return Ok("Acesso permitido");
    }
}