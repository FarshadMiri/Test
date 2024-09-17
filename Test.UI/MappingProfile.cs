using AutoMapper;
using Test.Application.DTOs;
using Test.Domain;
using Test.UI.Models.ViewModels.User;

namespace Test.UI
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserViewModel, UserDto>().ReverseMap();
            CreateMap<User, CreateUserViewModel>();
        }

    }
}
