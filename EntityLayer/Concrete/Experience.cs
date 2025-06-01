using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public  class Experience
    {
        public int ExperienceID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
