using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class UserEntity
    {[Key]
        [Required(ErrorMessage = "This field is Required")]
        public string email { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This field is Required")]
        public string FullName { get; set; }
        public string ProfileImage { get; set; }

        public ICollection<QuestionEntity> questions { get; set; }
        public ICollection<AnswerEntity> answers { get; set; }
        public ICollection<VoteEntity> vote { get; set; }


    }
}
