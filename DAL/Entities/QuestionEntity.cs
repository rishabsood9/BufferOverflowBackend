using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class QuestionEntity
    {[Key]
        public int questionId { get; set; }
        public string username { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string tags { get; set; }
        public int NumberOfAnswers { get; set; }
        public string QuestionImage {get;set;}
        public DateTime Date{get;set;}
        

        public ICollection<AnswerEntity> answers { get; set; }
              [ForeignKey("username")]
        public UserEntity users { get; set; }

    }
}
