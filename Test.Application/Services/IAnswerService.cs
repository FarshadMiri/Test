using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTOs;
using Test.Domain;

namespace Test.Application.Services
{
    public interface IAnswerService
    {
        void AddAnswer(AnswerDto answerDto);
        Task<IEnumerable<AnswerDto>> GetAnswersByUserId(int userId);    
        Task<AnswerDto> GetAnswerByQuestionIdAndUserId(int questionId, int userId);
        Task UpdateAnswer(AnswerDto answerDto);
        
    }
}
