using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public bool Status { get; set; }
        public List<UserMessage>? UserMessages { get; set; }
    }
}
