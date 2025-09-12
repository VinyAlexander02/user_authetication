using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using user_auth.Data.Dto;
using user_auth.Models;
using user_auth.Services;

namespace user_auth.Controller;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    
    private RegisterService _registerService;

    public UserController(RegisterService registerService)
    {
        _registerService = registerService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(CreateUserDto dto)
    {
        await _registerService.Register(dto);
        return Ok("Registered User");
    }
}