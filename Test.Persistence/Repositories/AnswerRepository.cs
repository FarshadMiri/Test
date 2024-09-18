using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Application.Contract.Persistence;
using Test.Domain;

namespace Test.Persistence.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly TestDbContext _context;
        public AnswerRepository(TestDbContext context)
        {
            _context = context;
        }
        public async Task<bool> SaveAnswer(Answer answer)
        {

            try
            {
                await _context.AddAsync(answer);
                 _context.SaveChanges();
                return true;
                    

            }
            catch (Exception ex)
            {
                var inner=ex.InnerException.Message;    
                return false;
            }
           






        }
    }
}
