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
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository  _answerRepository;
        private readonly IMapper _mapper;
        public AnswerService(IAnswerRepository answerRepository, IMapper mapper)
        {
              _answerRepository = answerRepository;
            _mapper = mapper;   
            
        }

        public void AddAnswer(AnswerDto answerDto)
        {
            var answer = new Answer()
            {
                
                 QuestionId = answerDto.QuestionId,
                  UserId = 1,
                   UserAnswer =answerDto.UserAnswer
            };
            _answerRepository.SaveAnswer(answer);
            
        }
    }
}
