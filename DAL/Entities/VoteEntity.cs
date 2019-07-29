using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
   public class VoteEntity
    { public bool vote { get; set; }
            [Key]
        public int voteId { get; set; }
        public string userId { get; set; }
        public int answerId { get; set; }
        public bool voter { get; set; }
        

        [ForeignKey("answerId")]
        public AnswerEntity answers { get; set; }
        [ForeignKey("userId")]
        public UserEntity user { get; set; }
    }
}
