using AutoMapper;
using Microsoft.AspNetCore.Identity;
using user_auth.Data.Dto;
using user_auth.Models;

namespace user_auth.Services;

public class RegisterService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;

    public RegisterService(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task Register(CreateUserDto dto)
    {
        User user = _mapper.Map<User>(dto);
        
        IdentityResult res = await _userManager.CreateAsync(user, dto.Password);

        
        if (!res.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastrar usuário. Detalhes: " + string.Join(", ", res.Errors.Select(e => e.Description)));
        }
    }
}