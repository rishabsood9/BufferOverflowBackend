using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
   public class VoteDTO
    {

        public bool vote { get; set; }
        
        public int voteId { get; set; }
        public string userId { get; set; }
        public int answerId { get; set; }
        public bool voter { get; set; }
        

    }
}
