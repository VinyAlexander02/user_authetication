using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using user_auth.Data.Dto;
using user_auth.Data.Dtos;
using user_auth.Models;
using user_auth.Services;

namespace user_auth.Controller;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    
    private UserService _userService;

    public UserController(UserService registerService)
    {
        _userService = registerService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> AddUser(CreateUserDto dto)
    {
        await _userService.Register(dto);
        return Ok("Registered User");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
       await _userService.Login(dto);
        return Ok("Usuário autenticado");
    }
}