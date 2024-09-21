using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Domain;

namespace Test.Application.Contract.Persistence
{
    public interface IAnswerRepository
    {
        Task<bool> SaveAnswer(Answer answer );
        Task<IEnumerable<Answer>> GetAnswersByUserId(int userId);
        Task<Answer> GetAnswerByQuestionIdAndUserId(int questionId,int userId);
        Task<bool> UpdateAnswer(Answer answer);
    }
}
