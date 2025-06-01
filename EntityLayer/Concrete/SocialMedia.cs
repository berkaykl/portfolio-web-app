using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SocialMedia
    {
        public int SocialMediaID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}
