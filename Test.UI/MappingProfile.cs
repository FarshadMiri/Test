using AutoMapper;
using Test.Application.DTOs;
using Test.UI.Models.ViewModels.Quiz;
using Test.UI.Models.ViewModels.User;

namespace Test.UI
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserViewModel, UserDto>().ReverseMap();
            CreateMap<ShowUserViewModel, ShowUserDto>().ReverseMap();
            CreateMap<ShowQuestionViewModel, ShowQuestionsDto>().ReverseMap();
            CreateMap<SubmitAnswerViewModel, AnswerDto>().ReverseMap();






        }

    }
}
