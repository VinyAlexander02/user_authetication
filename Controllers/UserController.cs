using Microsoft.AspNetCore.Mvc;
using user_auth.Data.Dto;

namespace user_auth.Controller;

[ApiController]
[Route("Controller")]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult AddUser(CreateUserDto dto)
    {
        throw new NotImplementedException(); 
    }
}