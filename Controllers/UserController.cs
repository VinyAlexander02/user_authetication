using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using user_auth.Data.Dto;
using user_auth.Models;

namespace user_auth.Controller;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IMapper _mapper;
    private UserManager<User> _userManager;

    public UserController(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(CreateUserDto dto)
    {
        User user = _mapper.Map<User>(dto);
        IdentityResult res = await _userManager.CreateAsync(user, dto.Password);

        if (res.Succeeded) return Ok("Registered User");

        throw new ApplicationException($"Failed to add user with id {res}");
    }
}