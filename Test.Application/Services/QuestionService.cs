using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Contract.Persistence;
using Test.Application.DTOs;
using Test.Domain;

namespace Test.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;
        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
                _mapper = mapper;
            _questionRepository = questionRepository;
        }

        public async Task<IEnumerable<ShowQuestionsDto>> GetAllQuestion()
        {
            var questions = await _questionRepository.GetAllQuestion();
            var questionDto = _mapper.Map<List<ShowQuestionsDto>>(questions);  // مپ کردن کاربران به DTOها


            return questionDto;

        }
    }
}
