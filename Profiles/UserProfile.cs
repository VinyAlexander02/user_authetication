namespace user_auth.Profile;
using AutoMapper;
using user_auth.Data.Dto;
using user_auth.Models;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }
}