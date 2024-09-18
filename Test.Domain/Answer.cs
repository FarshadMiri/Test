using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
       [ForeignKey("Question")]
        public int QuestionId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }  
        
        public string UserAnswer { get; set; }
        public Question Question { get; set; }


    }
}

