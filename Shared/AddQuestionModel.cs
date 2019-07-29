using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class AddQuestionModel
    {

        public string username { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string tags { get; set; }
        
        public DateTime Date { get; set; }
       
        public string image { get; set; }
        public string name { get; set; }
    }
}
