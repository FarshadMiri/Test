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
        public int AnswerId { get; set; }
        
       
        public int UserId { get; set; }
        public int QuestionId { get; set; }
       
        public string Choice { get; set; }

    }
}

