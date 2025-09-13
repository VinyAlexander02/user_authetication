using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using user_auth.Data.Dto;
using user_auth.Data.Dtos;
using user_auth.Models;

namespace user_auth.Services;

public class UserService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;
    private SignInManager<User> _singInManager;
    private TokenService _tokenService;

    public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _singInManager = signInManager;
        _tokenService = tokenService;
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

    public async Task<string> Login(LoginUserDto dto)
    {
        var res = await _singInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);

        if (!res.Succeeded)
        {
            throw new ApplicationException("Usuário não autenticado");
        }

        var user = _singInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.UserName.ToUpper());

        var token = _tokenService.GenerateToken(user);

        return token;
        
    }
}