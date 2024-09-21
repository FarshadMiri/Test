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

        public async Task<AnswerDto> GetAnswerByQuestionIdAndUserId(int questionId, int userId)
        {
           var answer= await _answerRepository.GetAnswerByQuestionIdAndUserId(questionId, userId);
            return _mapper.Map<AnswerDto>(answer);
        }

        public async Task<IEnumerable<AnswerDto>> GetAnswersByUserId(int userId)
        {
           var answer= await _answerRepository.GetAnswersByUserId(userId);
            return _mapper.Map<AnswerDto[]>(answer);

        }

        public  async Task UpdateAnswer(AnswerDto answerDto)
        {
            var answer = new Answer()
            {
                 Id = answerDto.Id,

                QuestionId = answerDto.QuestionId,
                UserId = 1,
                UserAnswer = answerDto.UserAnswer
            };
            await _answerRepository.UpdateAnswer(answer);
        }
    }
}
