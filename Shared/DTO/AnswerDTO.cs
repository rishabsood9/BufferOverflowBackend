using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class AnswerDTO
    {

        public string answers { get; set; }
        public DateTime Date { get; set; }
        public int AnswerId { get; set; }
        public int QuestionId { get; set; }
        public string useremail { get; set; }
        public int NumberOfUpVotes { get; set; }
        public int NumberOfDownVotes { get; set; }
        public string Ques { get; set; }

        public int NumberOfVotes { get; set; }

    }
}
