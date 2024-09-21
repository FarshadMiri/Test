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
    public class AnswerRepository : IAnswerRepository
    {
        private readonly TestDbContext _context;
        public AnswerRepository(TestDbContext context)
        {
            _context = context;
        }

        public async Task<Answer> GetAnswerByQuestionIdAndUserId(int questionId, int userId)
        {

            var answer=await _context.Answers.FirstOrDefaultAsync(a=>a.QuestionId==questionId && a.UserId==userId);
            return answer;


        }

        public async Task<IEnumerable<Answer>> GetAnswersByUserId(int userId)
        {
            var answers= await _context.Answers
            .Where(a => a.UserId ==userId )
            .ToListAsync();
            return answers; 
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

      

        public async Task<bool> UpdateAnswer(Answer answer)
        {
            try
            {
                // بررسی اینکه آیا این موجودیت از قبل در حافظه محلی کانتکست ردیابی می‌شود یا خیر
                var local = _context.Answers
                    .Local
                    .FirstOrDefault(entry => entry.Id == answer.Id);

                if (local != null)
                {
                    // جدا کردن موجودیت محلی (در حافظه) از کانتکست
                    _context.Entry(local).State = EntityState.Detached;
                }

                // حالا می‌توانیم موجودیت جدید را آپدیت کنیم
                _context.Answers.Update(answer);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                var stackTrace = ex.StackTrace;
                return false;
            }
        }
    }
}
