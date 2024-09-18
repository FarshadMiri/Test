using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTOs;
using Test.Domain;

namespace Test.Application.profile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, ShowUserDto>().ReverseMap();
            CreateMap<Question, ShowQuestionsDto>().ReverseMap();
            CreateMap<Answer, AnswerDto>().ReverseMap();






        }

    }
}
