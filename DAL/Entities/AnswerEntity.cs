using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class AnswerEntity
    {
        public string answers { get; set; }
        [Key]
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string useremail { get; set; }
        public DateTime Date { get; set; }
       
        public int NumberOfUpVotes { get; set; }
        public int NumberOfDownVotes { get; set; }
        public string Ques { get; set; }

        [ForeignKey("QuestionId")]
        public QuestionEntity question { get; set; }
       
        [ForeignKey("useremail")]
        public UserEntity users { get; set; }


        public ICollection<VoteEntity> votes { get; set; }



    }
}
