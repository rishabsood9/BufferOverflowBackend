using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DTO;

namespace Shared
{
    public class AddUserModel
    {
        public UserDTO user { get; set; }
        public string image { get; set; }
        public string name { get; set; }
    }
}
