using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Application.DTOs
{
    public class AnswerDto
    {
        
        public int UserId { get; set; }

        public int QuestionId { get; set; }
        public string UserAnswer { get; set; }
    }
}
