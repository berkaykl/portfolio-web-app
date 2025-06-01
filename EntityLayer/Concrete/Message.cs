using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        public int MessageID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
