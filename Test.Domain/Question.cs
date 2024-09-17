using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Domain
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
       
    }
}
