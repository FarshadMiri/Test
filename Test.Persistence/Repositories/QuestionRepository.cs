using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Contract.Persistence;
using Test.Domain;

namespace Test.Persistence.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly TestDbContext _context;
        public QuestionRepository(TestDbContext context)
        {
                _context = context; 
        }
        public async Task<IEnumerable<Question>> GetAllQuestion()
        {
            return await _context.Questions.ToListAsync();  
        }
    }
}
