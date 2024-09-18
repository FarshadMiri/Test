using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.DTOs;

namespace Test.Application.Services
{
    public interface IQuestionService
    {
        Task<IEnumerable<ShowQuestionsDto>> GetAllQuestion();
    }
}
