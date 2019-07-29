using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
   public class QuestionDTO
    {

        public int questionId { get; set; }
        public string username { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string tags { get; set; }
        public int NumberOfAnswers { get; set; }
        public DateTime Date { get; set; }
        public string QuestionImage { get; set; }
        


    }
}
